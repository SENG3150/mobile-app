using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Inspect.Models
{
    public class MajorAssembly
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("subAssemblies")]
        public List<SubAssembly> SubAssemblies { get; set; }
    }
}
