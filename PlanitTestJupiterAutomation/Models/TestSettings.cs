using Newtonsoft.Json;

namespace PlanitTestJupiterAutomation.Models
{
    public class TestSettings
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("timeout")]
        public int Timeout { get; set; }
        
        [JsonProperty("browser")]
        public string Browser { get; set; }
       
    }
}
