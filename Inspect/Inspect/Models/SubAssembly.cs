using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Inspect.Models
{
    public class SubAssembly
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("photos")]
        [JsonConverter(typeof(StringImageConverter))]
        public List<Image> Photos { get; set; }

        [JsonProperty("machineGeneralTest")]
        public MachineGeneralTest MachineGeneralTest { get; set; }

        [JsonProperty("oilTest")]
        public OilTest OilTest { get; set; }

        [JsonProperty("wearTest")]
        public WearTest WearTest { get; set; }
    }
}
