using System;

namespace JokeGenerator
{
    public class UserOptionHelper
    {

        public static bool IsContinueApplication(ConsoleKeyInfo keyInfo)
        {
            return keyInfo.KeyChar == '?';
        }

        public static bool IsExitApplication(ConsoleKeyInfo keyInfo)
        {
            return keyInfo.Key == ConsoleKey.Escape;
        }

        public static bool IsSelectedCategory(ConsoleKeyInfo keyInfo)
        {
            return keyInfo.Key == ConsoleKey.C || keyInfo.KeyChar == 'c';
        }

        public static bool IsSelectedRandomJoke(ConsoleKeyInfo keyInfo)
        {
            return keyInfo.Key == ConsoleKey.R || keyInfo.KeyChar == 'r';
        }

        public static bool IsAgreed(ConsoleKeyInfo keyInfo)
        {
            return keyInfo.Key == ConsoleKey.Y || keyInfo.KeyChar == 'y';
        }

        public static bool IsDisagreed(ConsoleKeyInfo keyInfo)
        {
            return keyInfo.Key == ConsoleKey.N || keyInfo.KeyChar == 'n';
        }

        public static bool IsValidDigit(ConsoleKeyInfo keyInfo)
        {
            return char.IsNumber(keyInfo.KeyChar);
        }

        #region Private Helper Methods
        private static char? GetEnteredKey(ConsoleKeyInfo consoleKeyInfo)
        {
            char? key = null;
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
            }
            return key;
        }
        #endregion
    }
}
