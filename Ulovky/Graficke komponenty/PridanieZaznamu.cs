using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Ulovky
{
    public partial class PridanieZaznamu : Form
    {
        public bool IsCancelled;
        public string Value { get; set; }
        public DialogResult Koniec { get; set; }

        public PridanieZaznamu(string text)
        {
            InitializeComponent();
            labelText.Text = text;
            IsCancelled = true;
            Koniec = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsCancelled = false;
            Value = textBoxValue.Text;
            Koniec = DialogResult.OK;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsCancelled = true;
            Koniec = DialogResult.Cancel;
            Close();
        }
    }
}
