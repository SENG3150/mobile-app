using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Inspect.Models
{
    public class OilTest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lead")]
        public int Lead { get; set; }

        [JsonProperty("copper")]
        public int Copper { get; set; }

        [JsonProperty("tin")]
        public int Tin { get; set; }

        [JsonProperty("iron")]
        public int Iron { get; set; }

        [JsonProperty("pq90")]
        public int Pq90 { get; set; }

        [JsonProperty("silicon")]
        public int Silicon { get; set; }

        [JsonProperty("sodium")]
        public int Sodium { get; set; }

        [JsonProperty("aluminium")]
        public int Aluminium { get; set; }

        [JsonProperty("water")]
        public double Water { get; set; }

        [JsonProperty("viscosity")]
        public int Viscosity { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("photos")]
        [JsonConverter(typeof(StringImageConverter))]
        public List<Image> Photos { get; set; }

        [JsonProperty("actionItem")]
        public ActionItem ActionItem { get; set; }
    }
}
