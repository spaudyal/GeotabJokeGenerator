using System;

namespace Geotab.Core
{
    public static class GlobalConstants
    {
        public const string JOKE_SUBJECT_DEFAULT = "Chuck Norris";
        public const int JOKE_COUNT_DEFAULT = 1;
    }

    public static class StringLiterals
    {
        public const string CATEGORY = "category";
        public const string RESULTS = "results";
    }

    public static class GeotabApiConstants
    {
        public const string GEOTAB_API_URL = "https://us-central1-geotab-interviews.cloudfunctions.net/";
        public const string NAME_SERVER_URL = "https://www.names.privserv.com/api/";
        public const int TIMEOUT_SECONDS = 30;   // IN SECONDS
        public const string JOKE_CATEGORY_ENDPOINT = "joke_category";
        public const string JOKE_ENDPOINT = "joke";

    }

    public static class GeotabMenuOptions
    {
        public const ConsoleKey VIEW_CATEGORY = ConsoleKey.C;
        public const ConsoleKey VIEW_RANDOM_JOKE = ConsoleKey.R;
        public const ConsoleKey EXIT_MENU = ConsoleKey.X;
        public const ConsoleKey EXIT_APPLICATION = ConsoleKey.Escape;
        public const ConsoleKey USER_OPTION_YES = ConsoleKey.Y;
        public const ConsoleKey USER_OPTION_NO = ConsoleKey.N;
    }
}
