using Newtonsoft.Json;

namespace MobileCamoes.Model
{

    public class Genrer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
