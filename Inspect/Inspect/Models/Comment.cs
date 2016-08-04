using Newtonsoft.Json;
using System;

namespace Inspect.Models
{
    public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("timeCommented")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime TimeCommented { get; set; }

        [JsonProperty("authorType")]
        public string AuthorType { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("author")]
        public User Author { get; set; }
    }
}
