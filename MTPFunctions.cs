using MultiThreadPokemon.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using MultiThreadPokemon.Utils;
using System.Linq;
using LazyCache;

namespace MultiThreadPokemon
{
    public class MTPFunctions : IMTPFunctions
    {
        IAppCache cache = new CachingService();
        public List<PokemonData> RetrieveDatabase(string databaseUri)
        {
            List<PokemonData> result = new List<PokemonData>();
            using (WebClient client = new WebClient())
            {
                string databaseJson = client.DownloadString(databaseUri);
                result = JsonConvert.DeserializeObject<List<PokemonData>>(databaseJson);
            }

            return result;
        }

        public List<Pokemon> RetrievePokemonFromDatabaseByGeneration(List<PokemonData> database, int generationIndex)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            using (WebClient client = new WebClient())
            {

                foreach (PokemonData pokemonData in database.Where(d => IsPokemonFromGeneration(generationIndex, d.Id)))
                {
                    // Get pokemon from memory cache or Store it in cache
                    Pokemon cachePokemon = cache.GetOrAdd<Pokemon>(pokemonData.Id.ToString(), entry =>
                    {
                        entry.SlidingExpiration = TimeSpan.FromMinutes(60); // 1h inactive cache
                        return JsonConvert.DeserializeObject<Pokemon>(client.DownloadString(pokemonData.Url));
                    });

                    // if last edit is behind, we need to synchronize the cache
                    if(cachePokemon.LastEdit < pokemonData.LastEdit)
                    {
                        string pokemonJson = client.DownloadString(pokemonData.Url);
                        cachePokemon =  JsonConvert.DeserializeObject<Pokemon>(pokemonJson);

                        // Remove the previous value stored in cache
                        cache.Remove(cachePokemon.Id.ToString());

                        // Store the new value in cache
                        cache.Add(cachePokemon.Id.ToString(),cachePokemon,TimeSpan.FromMinutes(60));
                    }

                    // Add pokemon to the list
                    pokemons.Add(cachePokemon);
                }
            }
            return pokemons;
        }

        public bool IsPokemonFromGeneration(int generationIndex, long pokemonid)
        {
            PokemonGenerations generation = PokemonGenerations.Generations.FirstOrDefault(g => g.GenerationIndex == generationIndex);
            if(generation is null)
            {
                return false;
            }

            return generation.LowerLimit <= pokemonid && generation.UpperLimit >= pokemonid;
        }
    }
}
