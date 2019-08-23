using System.Windows.Forms;

namespace Ulovky.Statistiky
{
    public class StatistikyListViewItem : ListViewItem
    {
        public StatistikyListViewItem(StatistikyItem sumarnaItem) : base(new[] { "", "", "", "", "" })
        {
            SubItems[0].Text = sumarnaItem.DruhRyby;
            SubItems[1].Text = sumarnaItem.Nastraha;
            SubItems[2].Text = sumarnaItem.Pocet + @"  ks";
            SubItems[3].Text = sumarnaItem.Vaha + @"  g";
            SubItems[4].Text = sumarnaItem.Priemer + @"  g";
        }
    }
}
