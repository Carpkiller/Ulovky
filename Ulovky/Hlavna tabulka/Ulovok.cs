using System;

namespace Ulovky
{
    public class Ulovok
    {
        public DateTime Datum { get; set; }
        public string CisloReviru { get; set; }
        public string NazovReviru { get; set; }
        public string Lokalita { get; set; }
        public string DruhRyby { get; set; }
        public decimal Dlzka { get; set; }
        public decimal Vaha { get; set; }
        public string SposobLovu { get; set; }
        public string Nastraha { get; set; }
        public bool Pustena { get; set; }
        public string Poznamky { get; set; }
        public bool FlagPoznamky { get; set; }

        public Ulovok(DateTime datum, string cisloReviru, string nazovReviru, string lokalita, string druhRyby, decimal dlzka, decimal vaha, string sposobLovu, string nastraha, bool pustena, string poznamky, bool flagPoznamky)
        {
            Datum = datum;
            CisloReviru = cisloReviru;
            NazovReviru = nazovReviru;
            Lokalita = lokalita;
            DruhRyby = druhRyby;
            Dlzka = dlzka;
            Vaha = vaha;
            SposobLovu = sposobLovu;
            Nastraha = nastraha;
            Pustena = pustena;
            Poznamky = poznamky;
            FlagPoznamky = flagPoznamky;
        }
    }
}
