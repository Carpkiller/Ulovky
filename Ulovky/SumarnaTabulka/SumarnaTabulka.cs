namespace Ulovky.SumarnaTabulka
{
    public class SumarnaTabulka
    {
        public string Rok { get; set; }
        public string Poradie { get; set; }
        public string DruhRyby { get; set; }
        public int Vaha { get; set; }
        public int Pocet { get; set; }
        public int Priemer { get; set; }

        public SumarnaTabulka(string rok, string poradie, string druhRyby, int vaha, int pocet)
        {
            Rok = rok;
            Poradie = poradie;
            DruhRyby = druhRyby;
            Vaha = vaha;
            Pocet = pocet;
            Priemer = vaha / pocet;
        }
    }
}
