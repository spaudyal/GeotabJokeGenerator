using System;
using System.Collections.Generic;
using Geotab.Model;
using Newtonsoft.Json;

namespace Geotab.Service
{
    public class ApiHelper
    {
        public static List<string> GetCategories()
        {
            new JsonFeed("https://us-central1-geotab-interviews.cloudfunctions.net/joke_category", 0);
            var results = JsonConvert.DeserializeObject<List<string>>(JsonFeed.GetCategories().Result);
            return results;
        }

        public static List<JokeModel> GetRandomJokes(JokeCategory category, JokeSubject subject, int number)
        {
            new JsonFeed("https://us-central1-geotab-interviews.cloudfunctions.net/joke", number);
            var results = JsonConvert.DeserializeObject<JokeModel>(JsonFeed.GetRandomJokes(subject, category).Result);
            return new() { results };
        }

        public static JokeSubject GetNames()
        {
            new JsonFeed("https://www.names.privserv.com/api/", 0);
            var result = JsonConvert.DeserializeObject<JokeSubject>(JsonFeed.Getnames().Result);
            return result;
        }
    }
}
