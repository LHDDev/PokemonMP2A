using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadPokemon.Utils
{
    public class PokemonGenerations
    {
        public int GenerationIndex { get; private set; }
        public int LowerLimit { get; private set; }
        public int UpperLimit { get; private set; }
        public static List<PokemonGenerations> Generations = new List<PokemonGenerations>{
            new PokemonGenerations(1, 1, 151),
            new PokemonGenerations(2, 152, 251),
            new PokemonGenerations(3, 252, 386),
            new PokemonGenerations(4, 387, 493),
            new PokemonGenerations(5, 494, 649),
            new PokemonGenerations(6, 650, 721),
            new PokemonGenerations(7, 722, 802),
            new PokemonGenerations(8, 803, 898)
        };

        // Private constructor to create public generations
        public PokemonGenerations(int generationIndex, int firstPokemonIndex, int lastPokemonIndex)
        {
            GenerationIndex = generationIndex;
            LowerLimit = firstPokemonIndex;
            UpperLimit = lastPokemonIndex;
        }
    }
}
