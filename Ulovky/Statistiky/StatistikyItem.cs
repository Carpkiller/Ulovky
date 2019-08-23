namespace Ulovky.Statistiky
{
    public class StatistikyItem
    {
        public string Rok { get; set; }
        public string DruhRyby { get; set; }
        public string Nastraha { get; set; }
        public string Revir { get; set; }
        public int? Vaha { get; set; }
        public int? Pocet { get; set; }
        public int? Priemer { get; set; }

        public StatistikyItem(string rok, string druhRyby, string nastraha, string revir, int? vaha, int? pocet, int? priemer)
        {
            Rok = rok;
            DruhRyby = druhRyby;
            Nastraha = nastraha;
            Revir = revir;
            Vaha = vaha;
            Pocet = pocet;
            Priemer = priemer;
        }
    }
}
