using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ulovky.Lokality
{
    public partial class Lokality : Form
    {
        private readonly Jadro _jadro;

        public Lokality(Jadro jadro)
        {
            InitializeComponent();
            _jadro = jadro;
            LoadComboboxes();
        }

        private void LoadComboboxes()
        {
            var input = new List<string>() { "" };
            input.AddRange(_jadro.SuggestCisloReviru);
            cbCisloReviru.DataSource = input;
        }

        private void cbCisloReviru_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLokality();            
        }

        private void LoadLokality()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            listView1.Items.AddRange(_jadro.LoadLokality(cbCisloReviru.Text));
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.EndUpdate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                txbLokalita.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txbPopis.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txbGps.Text = listView1.SelectedItems[0].SubItems[3].Text;

                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
                txbPopis.Enabled = false;
                txbGps.Enabled = false;
            }            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txbPopis.Enabled = true; 
            txbGps.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _jadro.LokalitaUpdate(cbCisloReviru.Text, txbLokalita.Text, txbPopis.Text, txbGps.Text);

            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            txbPopis.Enabled = false;
            txbGps.Enabled = false;

            LoadLokality();
        }
    }
}
