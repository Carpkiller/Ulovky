using System.Windows.Forms;

namespace Ulovky.SumarnaTabulka
{
    public class SumarnaTabulkaLiestViewItem : ListViewItem
    {
        public SumarnaTabulkaLiestViewItem(SumarnaTabulka sumarnaItem, int poradie)
            : base(new[] { "", "", "", "", ""})
        {
            if (sumarnaItem.DruhRyby != "Spolu : ")
            {
                SubItems[0].Text = poradie + @".";
            }
            else
            {
                SubItems[0].Text = @"---";
            }
            
            SubItems[1].Text = sumarnaItem.DruhRyby;
            SubItems[2].Text = sumarnaItem.Pocet +@"  ks";
            SubItems[3].Text = sumarnaItem.Vaha +@"  g";
            SubItems[4].Text = sumarnaItem.Priemer + @"  g";
        }
    }
}
