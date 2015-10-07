namespace Ulovky
{
    public class Revir
    {
        public string CisloReviru { get; set; }
        public string NazovReviru { get; set; }

        public Revir(string cisloReviru, string nazovReviru)
        {
            CisloReviru = cisloReviru;
            NazovReviru = nazovReviru;
        }
    }
}
