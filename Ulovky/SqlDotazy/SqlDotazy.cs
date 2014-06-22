namespace Ulovky.SqlDotazy
{
    public static class SqlDotazy
    {
        public static string QuerySuggestDruhRyby = "SELECT druh_ryby FROM druh_ryby;";
        public static string QuerySuggestNastraha = "SELECT distinct nastraha FROM ulovky;";
        public static string QuerySuggestSposobLovu = "SELECT distinct sposob_lovu FROM ulovky;";
        public static string QuerySuggestCisloReviru = "SELECT distinct cislo_reviru FROM ulovky;";
        public static string QuerySuggestNazovReviru = "SELECT distinct nazov_revir FROM ulovky;";

        public static string GetSumarneQuery(string rok, string user)
        {
            return "select distinct druh from ulovky where rok ='" + rok + "' and user ='"+user+"';";
        }

        public static string GetKompletneQuery(string user)
        {
            return "select distinct druh from ulovky where user ='"+user+"';";
        }
    }
}
