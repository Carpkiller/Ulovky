using System.Drawing;
using System.Windows.Forms;

namespace Ulovky.SumarnaTabulka
{
    public partial class SumarnaTabulkaFrom : Form
    {
        private Jadro _jadro;
        private int p;

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

        public SumarnaTabulkaFrom(Jadro jadro, bool p)
        {
            // TODO: Complete member initialization
            _jadro = jadro;
            InitializeComponent();

            listView1.BeginUpdate();
            listView1.Items.AddRange(_jadro.CelkovaTabulka());
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.EndUpdate();
            Text = @"Celkova tabulka - pouzivatel : " + _jadro.User;
        }

        public SumarnaTabulkaFrom(Jadro jadro, int p)
        {
            // TODO: Complete member initialization
            _jadro = jadro;
            if (p == 1)
            {
                InitializeComponent();
                listView1.Columns.Clear();
                listView1.Columns.AddRange(new ColumnHeader[]
                {
                    new ColumnHeader()
                    {
                        Text = "Datum"
                    },
                    new ColumnHeader()
                    {
                        Text = "Cislo reviru"
                    },
                    new ColumnHeader()
                    {
                        Text = "Nazov reviru"
                    },
                    new ColumnHeader()
                    {
                        Text = "Lokalita"
                    },
                    new ColumnHeader()
                    {
                        Text = "Druh ryby"
                    },
                    new ColumnHeader()
                    {
                        Text = "Dlzka"
                    },
                    new ColumnHeader()
                    {
                        Text = "Vaha"
                    },
                    new ColumnHeader()
                    {
                        Text = "Sposob lovu"
                    },
                    new ColumnHeader()
                    {
                        Text = "Nastraha"
                    },
                    new ColumnHeader()
                    {
                        Text = "Pustena"
                    }
                });
                listView1.BeginUpdate();
                listView1.Items.AddRange(_jadro.NajvacsieUlovky());
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.EndUpdate();
                Text = @"Najvacsie ulovky - pouzivatel : " + _jadro.User;
            }
        }
    }
}
