using Geotab.Core;
using Geotab.Model;
using Geotab.Service;

namespace JokeGenerator
{
    public class Application
    {
        public static void Start()
        {
            DisplayControl.ShowMainMenu();
            var userMenuChoice = ConsoleReader.ReadKey();
            switch (userMenuChoice.Key)
            {
                case GeoMenuOption.CATEGORY:
                    DisplayControl.PrintResults(ApiHelper.GetCategories());
                    break;
                case GeoMenuOption.RANDOM_JOKE:
                    JokeSubject jokeSubject = GetJokeSubject();
                    JokeCategory jokeCategory = GetJokeCategory();
                    int jokeCount = GetJokeCount();
                    DisplayControl.PrintResults(ApiHelper.GetRandomJokes(jokeCategory, jokeSubject, jokeCount));
                    break;
                default:
                    DisplayControl.ShowInvalidMessage(userMenuChoice.Key);
                    break;
            }
        }

        private static int GetJokeCount()
        {
            ConsolePrinter.Print("How many jokes do you want? (1-9).");
            return ConsoleReader.ReadDigit();
        }

        private static JokeCategory GetJokeCategory()
        {
            JokeCategory jokeCategory = null;
            ConsolePrinter.Print("Want to specify a category? y/n");
            if (UserOptionHelper.IsAgreed(ConsoleReader.ReadKey()))
            {
                ConsolePrinter.Print("Enter a category.");
                jokeCategory = new JokeCategory()
                {
                    Name = ConsoleReader.ReadLine()
                };
            }
            return jokeCategory;
        }

        private static JokeSubject GetJokeSubject()
        {
            JokeSubject subject = new JokeSubject();
            ConsolePrinter.Print("Want to use a random name? y/n");
            if (UserOptionHelper.IsAgreed(ConsoleReader.ReadKey()))
            {
                var tupleName = ApiHelper.GetNames();
                subject.FirstName = tupleName.Item1;
                subject.LastName = tupleName.Item2;
            }
            return subject;
        }
    }
}
