using System;
using System.Windows.Forms;

namespace PrepocetParser
{
    public partial class Form1 : Form
    {
        private readonly Jadro _jadro;
        public Form1()
        {
            InitializeComponent();
            _jadro = new Jadro();
            comboBox1.DataSource = _jadro.GetStringField("select druh_ryby from druh_ryby;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxVystup.Text = _jadro.VyparsujHodnoty(textBoxVstup.Text, comboBox1.SelectedValue.ToString());
        }
    }
}
