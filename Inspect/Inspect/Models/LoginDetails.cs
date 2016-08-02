using Newtonsoft.Json;

namespace Inspect.Models
{
    public class LoginDetails
    {
        [JsonProperty("type")]
        public string UserType { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
