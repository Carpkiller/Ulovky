using System;
using System.Linq;
using System.Windows.Forms;

namespace Ulovky
{
    public partial class Prihlasenie : Form
    {
        private readonly Jadro _jadro;
        public Prihlasenie(Jadro jadro)
        {
            _jadro = jadro;
            InitializeComponent();
            comboBoxUser.DataSource = _jadro.ListRokov.Select(x => x.Key).Distinct().ToList();
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRok.DataSource =
                _jadro.ListRokov.Where(x => x.Key == (string) comboBoxUser.SelectedValue)
                    .Select(x => x.Value)
                    .OrderByDescending(s => s)
                    .ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _jadro.User = comboBoxUser.SelectedValue.ToString();
            _jadro.Rok = int.Parse(comboBoxRok.SelectedValue.ToString());
           DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
