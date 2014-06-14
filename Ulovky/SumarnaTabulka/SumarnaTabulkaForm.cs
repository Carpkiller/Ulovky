using System.Drawing;
using System.Windows.Forms;

namespace Ulovky.SumarnaTabulka
{
    public partial class SumarnaTabulkaFrom : Form
    {
        public SumarnaTabulkaFrom(Jadro jadro)
        {
            var _jadro = jadro;
            InitializeComponent();

            listView1.BeginUpdate();
            listView1.Items.AddRange(_jadro.KoncorocnaTabulka());
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.EndUpdate();
            Text = @"Pouzivatel : " + _jadro.User + @" , rok : " + _jadro.Rok;

            var e = listView1;
            var h = listView1.Size.Height;
            //this.Size = new Size(600, listView1.Items.Count*35);

            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
