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
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
