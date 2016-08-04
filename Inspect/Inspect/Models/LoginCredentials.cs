using Newtonsoft.Json;

namespace Inspect.Models
{
    public class LoginCredentials
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
