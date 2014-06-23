using System;
using System.Globalization;
using System.Windows.Forms;

namespace Ulovky
{
    public partial class PridanieUlovku : Form
    {
        private readonly Jadro _jadro;
        private readonly long _index;

        public PridanieUlovku(Jadro jadro, int index)
        {
            _jadro = jadro;
            InitializeComponent();

            if (index != -1)
            {
                dateTimePicker1.Value = jadro.AktualnyRok[index].Datum;
                textBoxCisloReviru.Text = jadro.AktualnyRok[index].CisloReviru;
                textBoxDlzka.Text = jadro.AktualnyRok[index].Dlzka.ToString(CultureInfo.InvariantCulture);
                textBoxVaha.Text = jadro.AktualnyRok[index].Vaha.ToString(CultureInfo.InvariantCulture);
                textBoxDruhRyby.Text = jadro.AktualnyRok[index].DruhRyby;
                textBoxLokalita.Text = jadro.AktualnyRok[index].Lokalita;
                textBoxNastraha.Text = jadro.AktualnyRok[index].Nastraha;
                textBoxNazovReviru.Text = jadro.AktualnyRok[index].NazovReviru;
                textBoxSposobLovu.Text = jadro.AktualnyRok[index].SposobLovu;

                _index = jadro.AktualnyRok[index].Index;
            }

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
            sourceCisloReviru.AddRange(_jadro.SuggestCisloReviru);
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
            var pod = comboBoxPustena.SelectedItem.ToString() == "Ano";

            Ulovok = new Ulovok(_index, dateTimePicker1.Value, textBoxCisloReviru.Text,
                       textBoxNazovReviru.Text,
                       textBoxLokalita.Text, textBoxDruhRyby.Text, decimal.Parse(textBoxDlzka.Text),
                       decimal.Parse(textBoxVaha.Text), textBoxSposobLovu.Text, textBoxNastraha.Text,
                       comboBoxPustena.SelectedItem.ToString() == "Ano", textBoxPoznamky.Text,
                       string.IsNullOrEmpty(textBoxPoznamky.Text));
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxDlzka_TextChanged(object sender, EventArgs e)
        {
            textBoxVaha.Text = _jadro.PrepocitanaVaha(textBoxDruhRyby.Text, textBoxDlzka.Text);
        }
    }
}
