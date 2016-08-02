using Newtonsoft.Json;

namespace Inspect.Models
{
    public class Authentication
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
