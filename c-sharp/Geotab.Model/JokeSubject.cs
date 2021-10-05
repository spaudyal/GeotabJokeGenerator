using Newtonsoft.Json;

namespace Geotab.Model
{
    public class JokeSubject
    {
        [JsonProperty("name")]
        public string FirstName { get; set; }

        [JsonProperty("surname")]
        public string LastName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("region")]
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
