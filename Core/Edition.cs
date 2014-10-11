using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP
{
    public class Edition
    {
        [Newtonsoft.Json.JsonProperty("set")]
        public string Set { get; set; }

        [Newtonsoft.Json.JsonProperty("rarity")]
        public string Rarity { get; set; }

        [Newtonsoft.Json.JsonProperty("artist")]
        public string Artist { get; set; }

        [Newtonsoft.Json.JsonProperty("multiverse_id")]
        public int MultiverseId { get; set; }

        [Newtonsoft.Json.JsonProperty("flavor")]
        public string Flavor { get; set; }

        [Newtonsoft.Json.JsonProperty("number")]
        public int Number { get; set; }

        [Newtonsoft.Json.JsonProperty("layout")]
        public string Layout { get; set; }

        [Newtonsoft.Json.JsonProperty("price")]
        public Price Price { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("set_url")]
        public string SetUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("store_url")]
        public string StoreUrl { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - ${1}", this.Set, (this.Price.Average)/100.0m);
        }
    }
}
