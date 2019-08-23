namespace Ulovky.Statistiky
{
    partial class Statistiky
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderPoradie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDruh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPocet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVaha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPriemer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cbDruhRyby = new System.Windows.Forms.ComboBox();
            this.cbSposobLovu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRevir = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNastraha = new System.Windows.Forms.CheckBox();
            this.cbxRevir = new System.Windows.Forms.CheckBox();
            this.cbxSposobLovu = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPoradie,
            this.columnHeaderDruh,
            this.columnHeaderPocet,
            this.columnHeaderVaha,
            this.columnHeaderPriemer});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 87);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 351);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPoradie
            // 
            this.columnHeaderPoradie.Text = "Poradie";
            // 
            // columnHeaderDruh
            // 
            this.columnHeaderDruh.Text = "Druh ryby";
            // 
            // columnHeaderPocet
            // 
            this.columnHeaderPocet.Text = "Pocet";
            // 
            // columnHeaderVaha
            // 
            this.columnHeaderVaha.Text = "Vaha";
            // 
            // columnHeaderPriemer
            // 
            this.columnHeaderPriemer.Text = "Priemer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Druh ryby :";
            // 
            // cbDruhRyby
            // 
            this.cbDruhRyby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDruhRyby.FormattingEnabled = true;
            this.cbDruhRyby.Location = new System.Drawing.Point(91, 6);
            this.cbDruhRyby.Name = "cbDruhRyby";
            this.cbDruhRyby.Size = new System.Drawing.Size(222, 21);
            this.cbDruhRyby.TabIndex = 3;
            this.cbDruhRyby.SelectedIndexChanged += new System.EventHandler(this.cbDruhRyby_SelectedIndexChanged);
            // 
            // cbSposobLovu
            // 
            this.cbSposobLovu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSposobLovu.FormattingEnabled = true;
            this.cbSposobLovu.Location = new System.Drawing.Point(90, 33);
            this.cbSposobLovu.Name = "cbSposobLovu";
            this.cbSposobLovu.Size = new System.Drawing.Size(222, 21);
            this.cbSposobLovu.TabIndex = 5;
            this.cbSposobLovu.SelectedIndexChanged += new System.EventHandler(this.cbSposobLovu_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sposob lovu :";
            // 
            // cbRevir
            // 
            this.cbRevir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRevir.FormattingEnabled = true;
            this.cbRevir.Location = new System.Drawing.Point(90, 60);
            this.cbRevir.Name = "cbRevir";
            this.cbRevir.Size = new System.Drawing.Size(222, 21);
            this.cbRevir.TabIndex = 7;
            this.cbRevir.SelectedIndexChanged += new System.EventHandler(this.cbRevir_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Revir :";
            // 
            // cbxNastraha
            // 
            this.cbxNastraha.AutoSize = true;
            this.cbxNastraha.Checked = true;
            this.cbxNastraha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNastraha.Location = new System.Drawing.Point(391, 5);
            this.cbxNastraha.Name = "cbxNastraha";
            this.cbxNastraha.Size = new System.Drawing.Size(69, 17);
            this.cbxNastraha.TabIndex = 8;
            this.cbxNastraha.Text = "Nastraha";
            this.cbxNastraha.UseVisualStyleBackColor = true;
            this.cbxNastraha.CheckedChanged += new System.EventHandler(this.cbxNastraha_CheckedChanged);
            // 
            // cbxRevir
            // 
            this.cbxRevir.AutoSize = true;
            this.cbxRevir.Location = new System.Drawing.Point(391, 32);
            this.cbxRevir.Name = "cbxRevir";
            this.cbxRevir.Size = new System.Drawing.Size(51, 17);
            this.cbxRevir.TabIndex = 9;
            this.cbxRevir.Text = "Revir";
            this.cbxRevir.UseVisualStyleBackColor = true;
            this.cbxRevir.CheckedChanged += new System.EventHandler(this.cbxRevir_CheckedChanged);
            // 
            // cbxSposobLovu
            // 
            this.cbxSposobLovu.AutoSize = true;
            this.cbxSposobLovu.Location = new System.Drawing.Point(529, 5);
            this.cbxSposobLovu.Name = "cbxSposobLovu";
            this.cbxSposobLovu.Size = new System.Drawing.Size(85, 17);
            this.cbxSposobLovu.TabIndex = 10;
            this.cbxSposobLovu.Text = "Sposob lovu";
            this.cbxSposobLovu.UseVisualStyleBackColor = true;
            this.cbxSposobLovu.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Statistiky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxSposobLovu);
            this.Controls.Add(this.cbxRevir);
            this.Controls.Add(this.cbxNastraha);
            this.Controls.Add(this.cbRevir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSposobLovu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDruhRyby);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "Statistiky";
            this.Text = "Statistiky";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderPoradie;
        private System.Windows.Forms.ColumnHeader columnHeaderDruh;
        private System.Windows.Forms.ColumnHeader columnHeaderPocet;
        private System.Windows.Forms.ColumnHeader columnHeaderVaha;
        private System.Windows.Forms.ColumnHeader columnHeaderPriemer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDruhRyby;
        private System.Windows.Forms.ComboBox cbSposobLovu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRevir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxNastraha;
        private System.Windows.Forms.CheckBox cbxRevir;
        private System.Windows.Forms.CheckBox cbxSposobLovu;
    }
}