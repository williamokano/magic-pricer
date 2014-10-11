using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP
{
    public class Set
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("border")]
        public string Border { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("cards_url")]
        public string CardsUrl { get; set; }
    }
}
