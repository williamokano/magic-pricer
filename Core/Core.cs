using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace MP
{
    public class Core
    {

        private static CookieContainer cookieContainer = new CookieContainer();
        private static CookieContainer oldCookieContainer = new CookieContainer();

        /// <summary>
        /// Default constructor to be called when this class become used for the first time
        /// </summary>
        static Core()
        {
            ResetCookies();
        }

        /// <summary>
        /// Reset the cookie container
        /// </summary>
        /// <param name="keepBackup">If yes old cookies will be kept and can be returned, if needed. Use method restorePreviousCookies</param>
        private static void ResetCookies(bool keepBackup = false)
        {
            if (keepBackup)
                oldCookieContainer = cookieContainer;
            else
                oldCookieContainer = new CookieContainer();

            cookieContainer = new CookieContainer();
        }

        /// <summary>
        /// Restore the cookies before the last Reset with keepBackup
        /// </summary>
        private static void RestorePreviousCookies()
        {
            cookieContainer = oldCookieContainer;
            oldCookieContainer = new CookieContainer();
        }

        /// <summary>
        /// Make a simple Http Get Request
        /// </summary>
        /// <param name="url">URL of the website/API</param>
        /// <returns>A string from the website</returns>
        public static string Get(string url)
        {
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse webResp = (HttpWebResponse)webReq.GetResponse();
            string response = string.Empty;

            if (webResp.StatusCode == HttpStatusCode.OK)
            {
                Stream webRespStream = webResp.GetResponseStream();
                StreamReader sr = new StreamReader(webRespStream);

                response = sr.ReadToEnd();

                sr.Close();
                webRespStream.Close();
            }

            webResp.Close();

            return response;
        }

        /// <summary>
        /// Recovery the sets from the API
        /// </summary>
        /// <returns>A list containg all the sets provided by the API</returns>
        public static IList<Set> GetSets()
        {
            string response = Get("https://api.deckbrew.com/mtg/sets");
            IList<Set> sets = (IList<Set>)Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Set>>(response);
            return sets;
        }

        /// <summary>
        /// Search cards using name as filter
        /// </summary>
        /// <param name="name">Card's name (Full or partial)</param>
        /// <returns>The cards from the Brewdeck API</returns>
        public static IList<Card> Search(string name)
        {
            string response = Get(string.Format("https://api.deckbrew.com/mtg/cards?name={0}", name));

            IList<Card> cards = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Card>>(response);

            return cards;
        }

        /// <summary>
        /// Return the total value of the card's list
        /// </summary>
        /// <param name="cards"> The card's list given by the user</param>
        /// <returns></returns>
        public static decimal Sum(IList<Card> cards)
        {
            decimal sum = 0m;

            foreach (Card c in cards)
            {
                sum += (c.SelectedEdition.Price.Average) * c.Quantity;
            }

            return sum/100.0m;
        }

        /// <summary>
        /// Set the apropriate card edition given by the user
        /// </summary>
        /// <param name="card"></param>
        /// <param name="edition"></param>
        public static void SetSelectedEdition(Card card, Edition edition)
        {
            card.SelectedEdition = edition;
        }
    }
}
