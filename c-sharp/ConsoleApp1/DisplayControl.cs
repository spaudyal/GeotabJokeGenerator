using System;
using System.Collections.Generic;
using Geotab.Core;
using Geotab.Model;

namespace JokeGenerator
{
    class DisplayControl
    {
        public static void ShowInvalidMessage(ConsoleKeyInfo keyInfo)
        {
            ConsolePrinter.PrintLine($"Invalid input {keyInfo.KeyChar}. Please select valid options.");
            Logger.LogInfo($"User selected invalid option [{keyInfo}]");
        }

        public static void ShowInstructions()
        {
            ConsolePrinter.PrintLine("--------  APP START  --------");
            ConsolePrinter.PrintLine("Press ? key to get instructions.");
            ConsolePrinter.PrintLine("Press Escape (Esc) key to quit.");
        }

        public static void ShowMainMenu()
        {
            ConsolePrinter.PrintLine("--------  MENU ITEM  --------");
            ConsolePrinter.PrintLine("Press c to get categories");
            ConsolePrinter.PrintLine("Press r to get random jokes");
            ConsolePrinter.PrintLine("Press x to exit main menu");
        }

        public static void ShowApplicationExitMessage()
        {
            ConsolePrinter.PrintLine("Application Exit. Thanks for your time.");
            Logger.LogInfo($"User exited the application");
        }

        public static void ShowLeavingMessage()
        {
            ConsolePrinter.PrintLine("Logout to Application Menu");
            Logger.LogInfo($"User logged out");
        }


        public static void PrintJokes(List<JokeModel> jokes)
        {
            foreach (var joke in jokes)
            {
                ConsolePrinter.PrintLine(joke.ToString());
            }
        }

        public static void PrintCategories(List<string> categories)
        {
            PrintResults(categories.ToArray());
        }

        public static void PrintResults(string[] results)
        {
            ConsolePrinter.PrintLine($"[{string.Join(",", results)}]");
        }
    }
}