using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP
{
    public class Card
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("store_url")]
        public string StoreUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("types")]
        public IList<string> Types { get; set; }

        [Newtonsoft.Json.JsonProperty("colors")]
        public IList<string> Colors { get; set; }

        [Newtonsoft.Json.JsonProperty("cmc")]
        public int? Cmc { get; set; }

        [Newtonsoft.Json.JsonProperty("cost")]
        public string Cost { get; set; }

        [Newtonsoft.Json.JsonProperty("text")]
        public string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("editions")]
        public IList<Edition> Editions { get; set; }

        public Edition SelectedEdition { get; set; }

        private int quantity = 0;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value >= 0)
                {
                    quantity = value;
                }
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Card()
        {
            Types = new List<string>();
            Colors = new List<string>();
            Editions = new List<Edition>();
        }

        public Card(Card card)
        {
            this.Name = card.Name;
            this.Id = card.Id;
            this.Url = card.Url;
            this.StoreUrl = card.StoreUrl;
            this.Types = card.Types;
            this.Colors = card.Colors;
            this.Cmc = card.Cmc;
            this.Cost = card.Cost;
            this.Text = card.Text;
            this.Editions = new List<Edition>(card.Editions);
            this.SelectedEdition = card.SelectedEdition;
            this.Quantity = card.Quantity;

        }

        public override string ToString()
        {
            if (this.SelectedEdition == null)
            {
                return this.Name;
            }
            else
            {
                return string.Format("{0} - {1} - ${2}", this.Name, this.SelectedEdition.Set, (this.quantity*(this.SelectedEdition.Price.Average)/100.0m));
            }
            
        }

    }
}
