namespace Ulovky.SqlDotazy
{
    public static class SqlDotazy
    {
        public static string QuerySuggestDruhRyby = "SELECT druh_ryby FROM druh_ryby;";
        public static string QuerySuggestNastraha = "SELECT distinct nastraha FROM ulovky;";
        public static string QuerySuggestSposobLovu = "SELECT distinct sposob_lovu FROM ulovky;";

        public static string GetSumarneQuery(string rok)
        {
            return "select distinct druh from ulovky where rok ='" + rok + "';";
        }
    }
}
