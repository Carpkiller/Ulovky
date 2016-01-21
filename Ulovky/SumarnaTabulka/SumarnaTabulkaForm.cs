using System;
using System.Linq;
using System.Windows.Forms;

namespace Ulovky.SumarnaTabulka
{
    public partial class SumarnaTabulkaFrom : Form
    {
        public bool P { get; private set; }

        public SumarnaTabulkaFrom(Jadro jadro)
        {
            var _jadro = jadro;
            if (_jadro == null) throw new ArgumentNullException("_jadro");
            InitializeComponent();
            listView1.BeginUpdate();
            listView1.Items.AddRange(_jadro.KoncorocnaTabulka());
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.EndUpdate();
            Text = @"Pouzivatel : " + _jadro.User + @" , rok : " + _jadro.Rok;

            Height = 21*(jadro.KoncorocnaTabulka().Count() + 1) + 51;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public SumarnaTabulkaFrom(Jadro jadro, bool p)
        {
            P = p;
            Jadro jadro1 = jadro;
            InitializeComponent();

            listView1.BeginUpdate();
            listView1.Items.AddRange(jadro1.CelkovaTabulka());
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.EndUpdate();
            Text = @"Celkova tabulka - pouzivatel : " + jadro1.User;
            Height = (21*(jadro1.CelkovaTabulka().Count() + 1)) + 51;
        }

        public SumarnaTabulkaFrom(Jadro jadro, int p)
        {
            Jadro jadro1 = jadro;
            if (p == 1)
            {
                InitializeComponent();
                listView1.Columns.Clear();
                listView1.Columns.AddRange(new[]
                {
                    new ColumnHeader
                    {
                        Text = @"Datum"
                    },
                    new ColumnHeader
                    {
                        Text = @"Cislo reviru"
                    },
                    new ColumnHeader
                    {
                        Text = @"Nazov reviru"
                    },
                    new ColumnHeader
                    {
                        Text = @"Lokalita"
                    },
                    new ColumnHeader
                    {
                        Text = @"Druh ryby"
                    },
                    new ColumnHeader
                    {
                        Text = @"Dlzka"
                    },
                    new ColumnHeader
                    {
                        Text = @"Vaha"
                    },
                    new ColumnHeader
                    {
                        Text = @"Sposob lovu"
                    },
                    new ColumnHeader
                    {
                        Text = @"Nastraha"
                    },
                    new ColumnHeader
                    {
                        Text = @"Pustena"
                    }
                });
                listView1.BeginUpdate();
                listView1.Items.AddRange(jadro1.NajvacsieUlovky());
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.EndUpdate();
                Text = @"Najvacsie ulovky - pouzivatel : " + jadro1.User;
                Height = (21*(jadro1.CelkovaTabulka().Count() + 1)) + 51;
            }
        }
    }
}
