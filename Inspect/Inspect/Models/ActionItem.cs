using Newtonsoft.Json;
using System;

namespace Inspect.Models
{
    public class ActionItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("issue")]
        public string Issue { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("timeActioned")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime TimeActioned { get; set; }

        [JsonProperty("technician")]
        public User Techncian { get; set; }
    }
}
