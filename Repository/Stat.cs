using Newtonsoft.Json;

namespace MultiThreadPokemon.Repository
{
    public partial class Stat
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stat")]
        public long StatStat { get; set; }
    }
}
