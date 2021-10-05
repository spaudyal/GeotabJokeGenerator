using System;
using System.Collections.Generic;
using System.Text;
using Geotab.Core;
using Geotab.Model;
using Newtonsoft.Json;

namespace Geotab.Service
{
    public class ApiHelper
    {
        public static List<string> GetCategories()
        {
            //Create the geotab httpservice
            var categoryHttpService = new GeoTabApiService()
            {
                BaseUrl = GeotabApiConstants.GEOTAB_API_URL,
                TimeoutInSeconds = GeotabApiConstants.TIMEOUT_SECONDS
            };
            var results = JsonConvert.DeserializeObject<List<string>>(categoryHttpService.GetCategories().Result);
            return results;
        }

        public static List<JokeModel> GetRandomJokes(JokeCategory category, int jokeCount)
        {
            //Create the geotab httpservice
            var jokeHttpService = new GeoTabApiService()
            {
                BaseUrl = GeotabApiConstants.GEOTAB_API_URL,
                TimeoutInSeconds = GeotabApiConstants.TIMEOUT_SECONDS
            };
            string queryParameters = ConstructQueryParameters(category, jokeCount);
            JokeModel jokeModel = null;
            if (jokeCount > 1)
            {
                List<JokeModel> jokeList = new();
                var result = jokeHttpService.GetRandomMultipleJokes(queryParameters, jokeCount).Result;
                result.ForEach(jokeString =>
                {
                    jokeList.Add(JsonConvert.DeserializeObject<JokeModel>(jokeString));
                });
                return jokeList;
            }
            else
            {
                jokeModel = JsonConvert.DeserializeObject<JokeModel>(jokeHttpService.GetRandomJokes(queryParameters).Result);
                return new() { jokeModel };
            }
        }

        public static JokeSubject GetNames()
        {
            //Create the geotab httpservice
            var nameHttpService = new NameApiService()
            {
                BaseUrl = GeotabApiConstants.NAME_SERVER_URL,
                TimeoutInSeconds = GeotabApiConstants.TIMEOUT_SECONDS
            };
            var result = JsonConvert.DeserializeObject<JokeSubject>(nameHttpService.GetNames().Result);
            return result;
        }

        #region Private Helper Methods
        private static string ConstructQueryParameters(JokeCategory category, int jokeCount)
        {
            StringBuilder queryParameterString = new StringBuilder();
            if (category != null)
            {
                queryParameterString.Append($"{StringLiterals.CATEGORY}={category.Name}");
            }
            //if (jokeCount > 1)
            //{
            //    queryParameterString.Append("&");
            //    queryParameterString.Append($"{StringLiterals.RESULTS}={jokeCount}");
            //}

            return queryParameterString.ToString();
        }
        #endregion

        #region Deprecated Methods
        [Obsolete("This method should not be used anymore. Use GetNames() instead", true)]
        public static JokeSubject GetNames1()
        {
            new JsonFeed("https://www.names.privserv.com/api/", 0);
            var result = JsonConvert.DeserializeObject<JokeSubject>(JsonFeed.Getnames().Result);
            return result;
        }

        [Obsolete("This method should not be used anymore. Use GetCategories() instead", true)]
        public static List<string> GetCategories1()
        {
            new JsonFeed("https://us-central1-geotab-interviews.cloudfunctions.net/joke_category", 0);
            var results = JsonConvert.DeserializeObject<List<string>>(JsonFeed.GetCategories().Result);
            return results;
        }

        [Obsolete("This class should not be used anymore. Use GetRandomJokes() instead", true)]
        public static List<JokeModel> GetRandomJokes1(JokeCategory category, JokeSubject subject, int number)
        {
            new JsonFeed("https://us-central1-geotab-interviews.cloudfunctions.net/joke", number);
            var results = JsonConvert.DeserializeObject<JokeModel>(JsonFeed.GetRandomJokes(subject, category).Result);
            return new() { results };
        }
        #endregion
    }
}
