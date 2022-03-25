using MultiThreadPokemon.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadPokemon
{
    public interface IMTPFunctions
    {
        public List<PokemonData> RetrieveDatabase(string databaseUri);
        public List<Pokemon> RetrievePokemonFromDatabaseByGeneration(List<PokemonData> database, int generationIndex);
        public bool IsPokemonFromGeneration(int generationId, long pokemonId);
    }
}
