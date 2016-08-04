using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Inspect.Models
{
    public class MachineGeneralTest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("docLink")]
        public string DocumentLink { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("photos")]
        [JsonConverter(typeof(StringImageConverter))]
        public List<Image> Photos { get; set; }

        [JsonProperty("actionItem")]
        public ActionItem ActionItem { get; set; }
    }
}
