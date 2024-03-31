using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ulovky.Lokality;
using Ulovky.SumarnaTabulka;

namespace Ulovky
{
    public partial class Form1 : Form
    {
        private readonly Jadro _jadro;
        public Form1()
        {
            _jadro = new Jadro();
            InitializeComponent();
            //NastavListView();
            listView1.Visible = false;
            //listView1.BeginUpdate();
            //listView1.Items.AddRange(_jadro.NacitajUlovky(2013,"Lukas"));
            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //listView1.EndUpdate();
            Prihlasenie();
        }

        private void Prihlasenie()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.PoslednyRok) && !string.IsNullOrEmpty(Properties.Settings.Default.PoslednyUser))
            {
                _jadro.Rok = Properties.Settings.Default.PoslednyRok;
                _jadro.User = Properties.Settings.Default.PoslednyUser;

                listView1.Visible = true;
                listView1.BeginUpdate();
                listView1.Items.Clear();
                listView1.Items.AddRange(_jadro.NacitajUlovky());
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.EndUpdate();
                Text = @"Pouzivatel : " + _jadro.User + @" , rok : " + _jadro.Rok;
                _jadro.NastavNasledujuceRoky(buttonNasled, buttonPredch);
            }
        }

        private void prihlasenieToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var prihlasenieForm = new Prihlasenie(_jadro);
            //DialogResult result = prihlasenieForm.Show();
            if (prihlasenieForm.ShowDialog() == DialogResult.OK)
            {
                listView1.Visible = true;
                listView1.BeginUpdate();
                listView1.Items.Clear();
                listView1.Items.AddRange(_jadro.NacitajUlovky());
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.EndUpdate();
                Text = @"Pouzivatel : " + _jadro.User + @" , rok : " + _jadro.Rok;
                _jadro.NastavNasledujuceRoky(buttonNasled, buttonPredch);

                Properties.Settings.Default.PoslednyRok = _jadro.Rok;
                Properties.Settings.Default.PoslednyUser = _jadro.User;
                Properties.Settings.Default.Save();
            }
        }

        private void koncorocnaTabulkaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (_jadro.User == null || _jadro.Rok == null)
            {
                MessageBox.Show(@"Musis sa prihlasit", @"Chyba", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                SumarnaTabulkaFrom tabulka = new SumarnaTabulkaFrom(_jadro);
                tabulka.Show();
            }
        }

        private void buttonPredch_Click(object sender, System.EventArgs e)
        {
            _jadro.Rok = buttonPredch.Text;
            listView1.Visible = true;
            listView1.BeginUpdate();
            listView1.Items.Clear();
            listView1.Items.AddRange(_jadro.NacitajUlovky());
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.EndUpdate();
            Text = @"Pouzivatel : " + _jadro.User + @" , rok : " + _jadro.Rok;
            _jadro.NastavNasledujuceRoky(buttonNasled, buttonPredch);
        }

        private void buttonNasled_Click(object sender, System.EventArgs e)
        {
            _jadro.Rok = buttonNasled.Text;
            listView1.Visible = true;
            listView1.BeginUpdate();
            listView1.Items.Clear();
            listView1.Items.AddRange(_jadro.NacitajUlovky());
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.EndUpdate();
            Text = @"Pouzivatel : " + _jadro.User + @" , rok : " + _jadro.Rok;
            _jadro.NastavNasledujuceRoky(buttonNasled, buttonPredch);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var pridanieUlovku = new PridanieUlovku(_jadro, _jadro.AktualnyRok.Count-1);
            if (pridanieUlovku.ShowDialog() == DialogResult.OK)
            {
                _jadro.PridajUlovok(pridanieUlovku.Ulovok);
                listView1.BeginUpdate();
                listView1.Items.Clear();
                listView1.Items.AddRange(_jadro.NacitajUlovky());
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.EndUpdate();
            }
        }

        private void celkovaTabulkaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (_jadro.User == null || _jadro.Rok == null)
            {
                MessageBox.Show(@"Musis sa prihlasit", @"Chyba", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                SumarnaTabulkaFrom tabulka = new SumarnaTabulkaFrom(_jadro, true);
                tabulka.Show();
            }
        }

        private void tabulkaTopUlovkovToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (_jadro.User == null || _jadro.Rok == null)
            {
                MessageBox.Show(@"Musis sa prihlasit", @"Chyba", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                SumarnaTabulkaFrom tabulka = new SumarnaTabulkaFrom(_jadro, 1);
                tabulka.Show();
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                var pridanieUlovku = new PridanieUlovku(_jadro, listView1.SelectedIndices[0]);
                if (pridanieUlovku.ShowDialog() == DialogResult.OK)
                {
                    _jadro.EditUlovok(pridanieUlovku.Ulovok);
                    listView1.BeginUpdate();
                    listView1.Items.Clear();
                    listView1.Items.AddRange(_jadro.NacitajUlovky());
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    listView1.EndUpdate();
                }
            }
            else
            {
                MessageBox.Show(@"Musis vybrat nejaky ulovok, ktory chces editovat", @"Chyba", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                var mssgResult = MessageBox.Show(@"Naozaj chces odstranit tento zaznam?", @"Potvrdenie",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (mssgResult == DialogResult.OK)
                {
                    _jadro.ZmazZaznam(listView1.SelectedIndices[0]);
                    listView1.BeginUpdate();
                    listView1.Items.Clear();
                    listView1.Items.AddRange(_jadro.NacitajUlovky());
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    listView1.EndUpdate();
                }
            }
            else
            {
                MessageBox.Show(@"Musis vybrat nejaky ulovok, ktory chces zmazat", @"Chyba", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void rozsireneStatistikyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Statistiky.Statistiky statistiky = new Statistiky.Statistiky(_jadro);
            statistiky.Show();
        }

        private void zoznamLokalitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var lokality = new Lokality.Lokality(_jadro);
            lokality.Show();
        }
    }
}
