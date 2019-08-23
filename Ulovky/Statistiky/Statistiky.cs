using System.Collections.Generic;
using System.Windows.Forms;

namespace Ulovky.Statistiky
{
    public partial class Statistiky : Form
    {
        private Jadro _jadro;

        public Statistiky(Jadro jadro)
        {
            _jadro = jadro;
            InitializeComponent();
            LoadComboBoxes();
            listView1.BeginUpdate();
            listView1.Items.AddRange(_jadro.StatistickaTabluka(null, null));
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.EndUpdate();
        }

        private void LoadComboBoxes()
        {
            var input = new List<string>() { "" };
            input.AddRange(_jadro.SuggestDruhRyby);
            cbDruhRyby.DataSource = input;
            input = new List<string>() { "" };
            input.AddRange(_jadro.SuggestCisloReviru);
            cbRevir.DataSource = input;
            input = new List<string>() { "" };
            input.AddRange(_jadro.SuggestSposobLovu);
            cbSposobLovu.DataSource = input;
        }

        private void cbDruhRyby_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            listView1.Items.AddRange(_jadro.StatistickaTabluka("Nastraha", cbDruhRyby.Text));
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.Columns[0].Text = "Druh ryby";
            listView1.Columns[1].Text = "Nastraha";
            listView1.EndUpdate();
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cbxSposobLovu.Checked)
            {
                cbxNastraha.Checked = false;
                cbxRevir.Checked = false;
                cbxSposobLovu.Checked = true;

                listView1.BeginUpdate();
                listView1.Items.Clear();
                listView1.Items.AddRange(_jadro.StatistickaTabluka("Sposob", cbSposobLovu.Text));
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.Columns[0].Text = "Druh ryby";
                listView1.Columns[1].Text = "Sposob lovu";
                listView1.EndUpdate();
            }
        }

        private void cbxNastraha_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cbxNastraha.Checked)
            {
                cbxSposobLovu.Checked = false;
                cbxRevir.Checked = false;
                cbxNastraha.Checked = true;

                listView1.BeginUpdate();
                listView1.Items.Clear();
                listView1.Items.AddRange(_jadro.StatistickaTabluka("Nastraha", cbDruhRyby.Text));
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.Columns[0].Text = "Druh ryby";
                listView1.Columns[1].Text = "Nastraha";
                listView1.EndUpdate();
            }
        }

        private void cbSposobLovu_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            listView1.Items.AddRange(_jadro.StatistickaTabluka("Sposob", cbSposobLovu.Text));
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.Columns[0].Text = "Druh ryby";
            listView1.Columns[1].Text = "Sposob lovu";
            listView1.EndUpdate();
        }

        private void cbRevir_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            listView1.Items.AddRange(_jadro.StatistickaTabluka("Revir", cbSposobLovu.Text));
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.Columns[0].Text = "Druh ryby";
            listView1.Columns[1].Text = "Revir";
            listView1.EndUpdate();
        }

        private void cbxRevir_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cbxRevir.Checked)
            {
                cbxSposobLovu.Checked = false;
                cbxRevir.Checked = true;
                cbxNastraha.Checked = false;

                listView1.BeginUpdate();
                listView1.Items.Clear();
                listView1.Items.AddRange(_jadro.StatistickaTabluka("Revir", cbDruhRyby.Text));
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.Columns[0].Text = "Druh ryby";
                listView1.Columns[1].Text = "Revir";
                listView1.EndUpdate();
            }
        }
    }
}
