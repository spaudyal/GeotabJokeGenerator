using System;

namespace Geotab.Core
{
    public static class GlobalConstants
    {
        public const string CATEGORY = "category";
    }

    public static class GeoConstants
    {
        public const string GEOTAB_API_URL = "https://us-central1-geotab-interviews.cloudfunctions.net";
        public const string NAME_SERVER_URL = "https://www.names.privserv.com/api/";
        public const string JOKE_SUBJECT_DEFAULT = "Chuck Norris";
        public const int JOKE_COUNT_DEFAULT = 1;
    }

    public static class GeoMenuOption
    {
        public const ConsoleKey CATEGORY = ConsoleKey.C;
        public const ConsoleKey RANDOM_JOKE = ConsoleKey.R;
        public const ConsoleKey EXIT_MENU = ConsoleKey.X;
        public const ConsoleKey EXIT_APPLICATION = ConsoleKey.Escape;
        public const ConsoleKey USER_OPTION_YES = ConsoleKey.Y;
        public const ConsoleKey USER_OPTION_NO = ConsoleKey.N;
    }
}
