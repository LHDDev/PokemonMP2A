using Newtonsoft.Json;

namespace MultiThreadPokemon.Repository
{
    public partial class Translations
    {
        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("fr")]
        public string Fr { get; set; }

        public bool TranslationEqual(string name)
        {
            return string.Equals(name, Fr, System.StringComparison.OrdinalIgnoreCase) || string.Equals(name,En,System.StringComparison.OrdinalIgnoreCase);
        }
    }

}
