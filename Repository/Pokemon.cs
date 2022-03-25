using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MultiThreadPokemon.Repository
{
        public partial class Pokemon
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public Translations Name { get; set; }

            [JsonProperty("types")]
            public List<string> Types { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("weight")]
            public long Weight { get; set; }

            [JsonProperty("genus")]
            public Translations Genus { get; set; }

            [JsonProperty("description")]
            public Translations Description { get; set; }

            [JsonProperty("stats")]
            public List<Stat> Stats { get; set; }

            [JsonProperty("lastEdit")]
            public Int32 LastEdit { get; set; } // Last edit in unixTime

        public override string ToString()
        {
            return $"Pokemon #{Id} : {Name.Fr}";
        }
    }
    }
