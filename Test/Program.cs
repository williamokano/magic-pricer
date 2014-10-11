using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string response = MP.Core.Get("https://api.deckbrew.com/mtg/sets");
            IList<MP.Set> sets = MP.Core.GetSets();

            MP.Card card = new MP.Card();
            card.StoreUrl = "http://www.williamokano.com?DECKBREW";
        }
    }
}
