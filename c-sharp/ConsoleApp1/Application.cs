using System;
using System.Collections.Generic;
using System.Linq;
using Geotab.Core;
using Geotab.Model;
using Geotab.Service;

namespace JokeGenerator
{
    internal class Application : IDisposable
    {
        // TODO: We might need a background loader, or cleanup thes cache in certain interval to keep our cache updated
        private static HashSet<string> m_cachedCategory;
        public static void Start()
        {
            bool isExitToMainMenu;
            do
            {
                DisplayControl.ShowMainMenu();
                isExitToMainMenu = false;
                var userMenuChoice = ConsoleReader.ReadKey();
                switch (userMenuChoice.Key)
                {
                    case GeotabMenuOptions.VIEW_CATEGORY:
                        DisplayControl.PrintCategories(ReadOrGetCategories());
                        break;
                    case GeotabMenuOptions.VIEW_RANDOM_JOKE:
                        var userRequestForRandomName = TryGetJokeSubject(out JokeSubject randomName);
                        var jokeList = ApiHelper.GetRandomJokes(GetJokeCategory(), GetJokeCount());
                        if (userRequestForRandomName)
                        {
                            UpdateSubjectForJokes(jokeList, randomName);
                        }
                        DisplayControl.PrintJokes(jokeList);
                        break;
                    case GeotabMenuOptions.EXIT_MENU:
                        isExitToMainMenu = true;
                        DisplayControl.ShowLeavingMessage();
                        break;
                    default:
                        DisplayControl.ShowInvalidMessage(userMenuChoice);
                        break;
                }
            } while (!isExitToMainMenu);
        }

        public void Dispose()
        {
            m_cachedCategory.Clear();
        }

        #region Private Helper Methods

        private static void UpdateSubjectForJokes(List<JokeModel> jokeList, JokeSubject randomName)
        {
            jokeList.ForEach(joke =>
            {
                joke.UpdateSubjectNameBy(randomName.ToString());
            });
        }

        private static bool TryGetJokeSubject(out JokeSubject jokeSubject)
        {
            jokeSubject = null;
            ConsolePrinter.PrintLine("Want to use a random name? y/n");
            var userOption = ConsoleReader.ReadKey();
            if (UserOptionHelper.IsAgreed(userOption))
            {
                jokeSubject = ApiHelper.GetNames();
                return true;
            }
            if (!UserOptionHelper.IsDisagreed(userOption))
            {
                ConsolePrinter.Print($"Invalid Input [{userOption.Key}].");
            }
            ConsolePrinter.PrintLine($"Using default Subject [{GlobalConstants.JOKE_SUBJECT_DEFAULT}].");
            return false;
        }

        private static List<string> ReadOrGetCategories()
        {
            if (m_cachedCategory != null && m_cachedCategory.Count > 0)
            {
                return m_cachedCategory.ToList();
            }
            else
            {
                var categories = ApiHelper.GetCategories();
                m_cachedCategory = new(categories);
                return categories;
            }
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
                ConsolePrinter.PrintLine($"Invalid input. Using default count {GlobalConstants.JOKE_COUNT_DEFAULT}.");
                Logger.LogWarning($"Invalid input. Using default count {GlobalConstants.JOKE_COUNT_DEFAULT}.");
                return GlobalConstants.JOKE_COUNT_DEFAULT;
            }
        }

        private static JokeCategory GetJokeCategory()
        {
            ConsolePrinter.PrintLine("Want to specify a category? y/n");
            var userOption = ConsoleReader.ReadKey();
            if (UserOptionHelper.IsAgreed(userOption))
            {
                while (true)
                {
                    ConsolePrinter.PrintLine("Enter a category.");
                    var categoryName = ConsoleReader.ReadLine();
                    if (VerifyIfCategoryValid(categoryName))
                    {
                        return new()
                        {
                            Name = categoryName
                        };
                    }
                    else
                    {
                        ConsolePrinter.Print("Invalid Category. Categories can be: ");
                        DisplayControl.PrintCategories(ApiHelper.GetCategories());
                    }
                }
            }
            else
            {
                if (!UserOptionHelper.IsDisagreed(userOption))
                {
                    ConsolePrinter.Print($"Invalid Input [{userOption.Key}].");
                }
                ConsolePrinter.PrintLine($"No category selected.");
            }
            return null;
        }

        private static bool VerifyIfCategoryValid(string categoryName)
        {
            // Validate the Category (the API call will throw internal server error if invalid category is passed)
            List<string> validCategories = ReadOrGetCategories();
            return validCategories.Contains(categoryName, StringComparer.OrdinalIgnoreCase);
        }
        #endregion 
    }
}
