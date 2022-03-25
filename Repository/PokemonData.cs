using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadPokemon.Repository
{
    public partial class PokemonData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("lastEdit")]
        public Int32 LastEdit { get; set; } // Last Edit in unixtime
    }
}
