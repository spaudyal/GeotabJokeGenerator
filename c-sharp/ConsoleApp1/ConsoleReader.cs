using System;
using Geotab.Core;

namespace JokeGenerator
{
    class ConsoleReader
    {
        public static ConsoleKeyInfo ReadKey()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            if (consoleKeyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine(ConsoleKey.Escape.ToString());
            }
            else
            {
                Console.WriteLine(consoleKeyInfo.KeyChar);
            }
            return consoleKeyInfo;
        }

        public static string ReadLine()
        {
            string userString = Console.ReadLine();
            return userString;
        }

        public static int ReadDigit()
        {
            var userString = Console.ReadLine();
            if (int.TryParse(userString, out int result))
            {
                return result;
            }
            Logger.LogWarning($"User provided invalid input [{userString}] for jokes count. Use default value {GeoConstants.JOKE_COUNT_DEFAULT}");
            return GeoConstants.JOKE_COUNT_DEFAULT;
        }
    }
}
