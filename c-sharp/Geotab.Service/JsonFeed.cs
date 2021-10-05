using System;
using System.Net.Http;
using System.Threading.Tasks;
using Geotab.Core;
using Geotab.Model;

namespace Geotab.Service
{
    // TODO Improve the HttpClient request class
    class JsonFeed
    {
        static string _url = "";

        public JsonFeed() { }
        public JsonFeed(string endpoint, int results)
        {
            _url = endpoint;
        }

        public static async Task<string> GetRandomJokes(JokeSubject subject, JokeCategory category)
        {
            try
            {
                HttpClient client = new();
                client.BaseAddress = new(_url);
                string url = string.Empty;
                if (category != null)
                {
                    url += "?";
                    url += "category=";
                    url += category.Name;
                }
                // TODO
                Logger.Debug($"Making API Call to {url}");
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException httpException)
            {
                Logger.LogError("The http response failed due to network/server issue.", httpException);
                throw;
            }
        }

        /// <summary>
        /// returns an object that contains name and surname
        /// </summary>
        /// <param name="client2"></param>
        /// <returns></returns>
		public static async Task<string> Getnames()
        {
            try
            {
                HttpClient client = new();
                client.BaseAddress = new(_url);
                Logger.Debug($"Making API Call to {_url}");
                var response = await client.GetAsync("");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException httpException)
            {
                Logger.LogError("The http response failed due to network/server issue.", httpException);
                throw;
            }
        }

        public static async Task<string> GetCategories()
        {
            try
            {
                HttpClient client = new();
                Logger.Debug($"Making API Call to {_url}");
                var response = await client.GetAsync(new Uri(_url));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException httpException)
            {
                Logger.LogError("The http response failed due to network/server issue.", httpException);
                throw;
            }
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
