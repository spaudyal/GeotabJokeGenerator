using System;

namespace JokeGenerator
{
    public class ConsolePrinter
    {
        public static void PrintLine(string value)
        {
            Console.WriteLine(value);
        }

        public static void Print(string value)
        {
            Console.Write(value);
        }
    }
}
