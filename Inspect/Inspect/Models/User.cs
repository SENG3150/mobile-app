using Newtonsoft.Json;
using System;

namespace Inspect.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("temporary")]
        public bool IsTemporary { get; set; }

        [JsonProperty("loginExpiresTime")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime LoginExpiresTime { get; set; }

        [JsonProperty("expired")]
        public bool HasExpired { get; set; }

        [JsonProperty("emailHash")]
        public string EmailHash { get; set; }
    }
}
