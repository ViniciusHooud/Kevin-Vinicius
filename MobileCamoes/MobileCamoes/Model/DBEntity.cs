using Newtonsoft.Json;

namespace MobileCamoes.Model
{
    public class DBEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
