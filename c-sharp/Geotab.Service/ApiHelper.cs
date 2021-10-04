using System;
using Geotab.Model;


namespace Geotab.Service
{
    public class ApiHelper
    {
        public static string[] GetCategories()
        {
            new JsonFeed("https://us-central1-geotab-interviews.cloudfunctions.net/joke_category", 0);
            return JsonFeed.GetCategories();
        }

        public static string[] GetRandomJokes(JokeCategory category, JokeSubject subject, int number)
        {
            new JsonFeed("https://us-central1-geotab-interviews.cloudfunctions.net/joke", number);
            return JsonFeed.GetRandomJokes(subject, category);
        }

        public static Tuple<string, string> GetNames()
        {
            new JsonFeed("https://www.names.privserv.com/api/", 0);
            dynamic result = JsonFeed.Getnames();
            return Tuple.Create(result.name.ToString(), result.surname.ToString());
        }
    }
}
