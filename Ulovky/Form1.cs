using System.Windows.Forms;
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
            }
        }

        private void koncorocnaTabulkaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SumarnaTabulkaFrom tabulka = new SumarnaTabulkaFrom(_jadro);
            tabulka.Show();
        }

        private void buttonPredch_Click(object sender, System.EventArgs e)
        {
            _jadro.Rok = int.Parse(buttonPredch.Text);
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
            _jadro.Rok = int.Parse(buttonNasled.Text);
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
            var pridanieUlovku = new PridanieUlovku(_jadro);
            if (pridanieUlovku.ShowDialog() == DialogResult.OK)
            {
                _jadro.PridajUlovok(pridanieUlovku.Ulovok);
            }
        }

        private void celkovaTabulkaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SumarnaTabulkaFrom tabulka = new SumarnaTabulkaFrom(_jadro,true);
            tabulka.Show();
        }

        private void tabulkaTopUlovkovToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SumarnaTabulkaFrom tabulka = new SumarnaTabulkaFrom(_jadro, 1);
            tabulka.Show();
        }
    }
}
