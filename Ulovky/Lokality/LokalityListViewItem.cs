using System.Windows.Forms;

namespace Ulovky.Lokality
{
    public class LokalityListViewItem : ListViewItem
    {
        public LokalityListViewItem(LokalityItem lokalityItem) : base(new[] { "", "", "", ""})
        {
            SubItems[0].Text = lokalityItem.CisloReviru;
            SubItems[1].Text = lokalityItem.LokalitaNazov;
            SubItems[2].Text = lokalityItem.Popis;
            SubItems[3].Text = lokalityItem.Gps;
        }
    }
}
