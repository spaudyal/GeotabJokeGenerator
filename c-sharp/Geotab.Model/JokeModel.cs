using Newtonsoft.Json;

namespace Geotab.Model
{
    public class JokeModel
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("icon_url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return $"Joke: {Value}";
        }
    }
}
