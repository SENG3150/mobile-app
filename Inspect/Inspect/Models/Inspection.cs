using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Inspect.Models
{
    public class Inspection
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("timeCreated")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime TimeCreated { get; set; }

        [JsonProperty("timeScheduled")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime TimeScheduled { get; set; }

        [JsonProperty("timeStarted")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime Timestarted { get; set; }

        [JsonProperty("timeCompleted")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime TimeCompleted { get; set; }

        [JsonProperty("majorAssemblies")]
        public List<MajorAssembly> MajorAssemblies { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("photos")]
        [JsonConverter(typeof(StringImageConverter))]
        public List<Image> Photos { get; set; }
    }
}
