using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP
{
    public class Price
    {
        [Newtonsoft.Json.JsonProperty("low")]
        public int Low { get; set; }

        [Newtonsoft.Json.JsonProperty("median")]
        public int Average { get; set; }

        [Newtonsoft.Json.JsonProperty("high")]
        public int High { get; set; }
    }
}
