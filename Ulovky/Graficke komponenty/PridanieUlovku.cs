using System;
using System.Windows.Forms;

namespace Ulovky
{
    public partial class PridanieUlovku : Form
    {
        private readonly Jadro _jadro;
        public PridanieUlovku(Jadro jadro)
        {
            _jadro = jadro;
            InitializeComponent();

            var sourceDruhRyby = new AutoCompleteStringCollection();
            sourceDruhRyby.AddRange(_jadro.SuggestDruhRyby);
            textBoxDruhRyby.AutoCompleteCustomSource = sourceDruhRyby;
            textBoxDruhRyby.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxDruhRyby.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var sourceNastraha = new AutoCompleteStringCollection();
            sourceNastraha.AddRange(_jadro.SuggestNastraha);
            textBoxNastraha.AutoCompleteCustomSource = sourceNastraha;
            textBoxNastraha.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxNastraha.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var sourceSposobLovu = new AutoCompleteStringCollection();
            sourceSposobLovu.AddRange(_jadro.SuggestSposobLovu);
            textBoxSposobLovu.AutoCompleteCustomSource = sourceSposobLovu;
            textBoxSposobLovu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxSposobLovu.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var sourceCisloReviru = new AutoCompleteStringCollection();
            sourceSposobLovu.AddRange(_jadro.SuggestCisloReviru);
            textBoxCisloReviru.AutoCompleteCustomSource = sourceCisloReviru;
            textBoxCisloReviru.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxCisloReviru.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var sourceNazovReviru = new AutoCompleteStringCollection();
            sourceNazovReviru.AddRange(_jadro.SuggestNazovReviru);
            textBoxNazovReviru.AutoCompleteCustomSource = sourceNazovReviru;
            textBoxNazovReviru.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxNazovReviru.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public Ulovok Ulovok { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Ulovok = new Ulovok(dateTimePicker1.Value,textBoxCisloReviru.Text,textBoxNazovReviru.Text,textBoxLokalita.Text,textBoxDruhRyby.Text,decimal.Parse(textBoxDlzka.Text),
                decimal.Parse(textBoxVaha.Text), textBoxSposobLovu.Text, textBoxNastraha.Text, comboBoxPustena.SelectedItem.ToString()=="Ano", textBoxPoznamky.Text, string.IsNullOrEmpty(textBoxPoznamky.Text));
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
