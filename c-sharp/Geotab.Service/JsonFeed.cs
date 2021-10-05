using System;
using System.Collections.Generic;
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

        public static async Task<string> GetRandomJokes(JokeSubject subject, JokeCategory category)
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
            // TODO
            Logger.Debug($"Making API Call to {url}");
            return await Task.FromResult(client.GetStringAsync(url).Result);
        }

        /// <summary>
        /// returns an object that contains name and surname
        /// </summary>
        /// <param name="client2"></param>
        /// <returns></returns>
		public static async Task<string> Getnames()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            Logger.Debug($"Making API Call to {_url}");
            return await Task.FromResult(client.GetStringAsync("").Result);
            
        }

        public static async Task<string> GetCategories()
        {
            HttpClient client = new HttpClient();
            Logger.Debug($"Making API Call to {_url}");
            return await Task.FromResult(client.GetStringAsync(new Uri(_url)).Result);
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
