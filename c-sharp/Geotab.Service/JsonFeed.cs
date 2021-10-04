using System;
using System.Net.Http;
using System.Threading.Tasks;
using Geotab.Core;
using Geotab.Model;
using Newtonsoft.Json;

namespace Geotab.Service
{
    class JsonFeed
    {
        static string _url = "";

        public JsonFeed() { }
        public JsonFeed(string endpoint, int results)
        {
            _url = endpoint;
        }

        public static string[] GetRandomJokes(JokeSubject subject, JokeCategory category)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            string url = string.Empty;
            if (category != null)
            {
                url += "?";
                url += "category=";
                url += category.Name;
            }

            Logger.Debug($"Making API Call to {url}");
            string joke = Task.FromResult(client.GetStringAsync(url).Result).Result;

            if (subject != null)
            {
                int index = joke.IndexOf(GeoConstants.JOKE_SUBJECT_DEFAULT);
                string firstPart = joke.Substring(0, index);
                string secondPart = joke.Substring(0 + index + GeoConstants.JOKE_SUBJECT_DEFAULT.Length, joke.Length - (index + GeoConstants.JOKE_SUBJECT_DEFAULT.Length));
                joke = firstPart + " " + subject.FirstName + " " + subject.LastName + secondPart;
            }

            return new string[] { JsonConvert.DeserializeObject<dynamic>(joke).value };
        }

        /// <summary>
        /// returns an object that contains name and surname
        /// </summary>
        /// <param name="client2"></param>
        /// <returns></returns>
		public static dynamic Getnames()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            Logger.Debug($"Making API Call to {_url}");
            var result = client.GetStringAsync("").Result;
            //TODO use the Subject DTO here
            return JsonConvert.DeserializeObject<dynamic>(result);
        }

        public static string[] GetCategories()
        {
            HttpClient client = new HttpClient();
            Logger.Debug($"Making API Call to {_url}");
            return new string[] { Task.FromResult(client.GetStringAsync(new Uri(_url)).Result).Result };
        }

        //public static string ConstructUri()
        //{
        //    UriBuilder uriBuilder = new UriBuilder();

        //    string url = string.Empty;
        //    if (category != null)
        //    {
        //        url += "?";
        //        url += "category=";
        //        url += category.Name;
        //    }

        //}
    }
}
