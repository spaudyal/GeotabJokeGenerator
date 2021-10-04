using System;
using Geotab.Core;

namespace JokeGenerator
{
    class DisplayControl
    {
        public static void ShowInvalidMessage(ConsoleKey key)
        {
            ConsolePrinter.Print("Invalid input. Please select valid options.");
            Logger.LogInfo($"User selected invalid option [{key}]");
        }

        public static void ShowInstructions()
        {
            ConsolePrinter.Print($"Press ? key to get instructions.");
            ConsolePrinter.Print("Press Escape (Esc) key to quit.");
        }

        public static void ShowMainMenu()
        {
            ConsolePrinter.Print("Press c to get categories");
            ConsolePrinter.Print("Press r to get random jokes");
        }

        public static void ShowApplicationExitMessage()
        {
            ConsolePrinter.Print("Application Exit. Thanks for your time.");
            Logger.LogInfo($"User exited the application");
        }

        public static void PrintResults(string[] results)
        {
            ConsolePrinter.Print($"[{string.Join(",", results)}]");
        }
    }
}
