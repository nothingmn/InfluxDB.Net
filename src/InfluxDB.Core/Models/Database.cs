using Newtonsoft.Json;

namespace InfluxDB.Core.Models
{
    public class Database
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}