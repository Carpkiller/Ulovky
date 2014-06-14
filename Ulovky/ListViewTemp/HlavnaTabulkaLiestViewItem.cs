using System.Windows.Forms;

namespace Ulovky.ListViewTemp
{
    public class HlavnaTabulkaLiestViewItem : ListViewItem
    {
        public HlavnaTabulkaLiestViewItem(Ulovok ulovok, int poradie)
            : base(new[] { "", "", "", "", "", "", "", "", "", "", "", "", "" })
        {
            SubItems[0].Text = ulovok.Datum.ToString("dddd, d MMMM, yyyy");
            SubItems[1].Text = ulovok.CisloReviru;
            SubItems[2].Text = ulovok.NazovReviru;
            SubItems[3].Text = ulovok.Lokalita;
            SubItems[4].Text = poradie.ToString() +".";
            SubItems[5].Text = ulovok.DruhRyby;
            SubItems[6].Text = ulovok.Dlzka.ToString()+ "  cm";
            SubItems[7].Text = ulovok.Vaha.ToString()+ "  g";
            SubItems[8].Text = ulovok.SposobLovu;
            SubItems[9].Text = ulovok.Nastraha;
            SubItems[10].Text = ulovok.Pustena.ToString();
            SubItems[11].Text = ulovok.FlagPoznamky.ToString();
        }

    }
}
