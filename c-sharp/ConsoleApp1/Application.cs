using Geotab.Core;
using Geotab.Model;
using Geotab.Service;

namespace JokeGenerator
{
    public class Application
    {
        public static void Start()
        {
            bool isInvalidInput;
            do
            {
                DisplayControl.ShowMainMenu();
                isInvalidInput = false;
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
                        isInvalidInput = true;
                        DisplayControl.ShowInvalidMessage(userMenuChoice);
                        break;
                }
            } while (isInvalidInput);
        }

        private static int GetJokeCount()
        {
            ConsolePrinter.PrintLine("How many jokes do you want? (1-9).");
            if (ConsoleReader.TryReadDigit(out int jokeCount))
            {
                return jokeCount;
            }
            else
            {
                ConsolePrinter.PrintLine($"Invalid input. Using default count {GeoConstants.JOKE_COUNT_DEFAULT}.");
                Logger.LogWarning($"Invalid input. Using default count {GeoConstants.JOKE_COUNT_DEFAULT}.");
                return GeoConstants.JOKE_COUNT_DEFAULT;
            }
        }

        private static JokeCategory GetJokeCategory()
        {
            JokeCategory jokeCategory = null;
            ConsolePrinter.PrintLine("Want to specify a category? y/n");
            var userOption = ConsoleReader.ReadKey();
            if (UserOptionHelper.IsAgreed(userOption))
            {
                ConsolePrinter.PrintLine("Enter a category.");
                jokeCategory = new JokeCategory()
                {
                    Name = ConsoleReader.ReadLine()
                };
            }
            else
            {
                if (!UserOptionHelper.IsDisagreed(userOption))
                {
                    ConsolePrinter.Print($"Invalid Input [{userOption.Key}].");
                }
                ConsolePrinter.PrintLine($"No category selected.");
            }
            return jokeCategory;
        }

        private static JokeSubject GetJokeSubject()
        {
            JokeSubject subject = new JokeSubject();
            ConsolePrinter.PrintLine("Want to use a random name? y/n");
            var userOption = ConsoleReader.ReadKey();
            if (UserOptionHelper.IsAgreed(userOption))
            {
                var tupleName = ApiHelper.GetNames();
                subject.FirstName = tupleName.Item1;
                subject.LastName = tupleName.Item2;
            }
            else
            {
                if (!UserOptionHelper.IsDisagreed(userOption))
                {
                    ConsolePrinter.Print($"Invalid Input [{userOption.Key}].");
                }
                ConsolePrinter.PrintLine($"Using default Subject Name [{subject}].");
            }
            return subject;
        }
    }
}
