namespace Ulovky
{
    public class PrepoctoveTabulkyItem
    {
        public string Druh { get; set; }
        public string Dlzka { get; set; }
        public string Vaha { get; set; }

        public PrepoctoveTabulkyItem(string druh, string dlzka, string vaha)
        {
            Druh = druh;
            Dlzka = dlzka;
            Vaha = vaha;
        }
    }
}
