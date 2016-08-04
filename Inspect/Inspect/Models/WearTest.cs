using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Inspect.Models
{
    public class WearTest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("timeStarted")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime Timestarted { get; set; }

        [JsonProperty("smu")]
        public int Smu { get; set; }

        [JsonProperty("uniqueDetails")]
        public int UniqueDetails { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("photos")]
        [JsonConverter(typeof(StringImageConverter))]
        public List<Image> Photos { get; set; }

        [JsonProperty("actionItem")]
        public ActionItem ActionItem { get; set; }
    }
}
