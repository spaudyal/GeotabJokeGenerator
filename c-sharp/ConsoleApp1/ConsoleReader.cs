using System;

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

        public static bool TryReadDigit(out int result)
        {
            var userString = Console.ReadLine();
            return int.TryParse(userString, out result);
        }
    }
}
