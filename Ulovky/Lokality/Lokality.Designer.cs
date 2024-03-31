namespace Ulovky.Lokality
{
    partial class Lokality
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
            this.cbCisloReviru = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderPoradie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDruh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPocet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVaha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txbLokalita = new System.Windows.Forms.TextBox();
            this.txbGps = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPopis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbCisloReviru
            // 
            this.cbCisloReviru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCisloReviru.FormattingEnabled = true;
            this.cbCisloReviru.Location = new System.Drawing.Point(92, 12);
            this.cbCisloReviru.Name = "cbCisloReviru";
            this.cbCisloReviru.Size = new System.Drawing.Size(222, 21);
            this.cbCisloReviru.TabIndex = 17;
            this.cbCisloReviru.SelectedIndexChanged += new System.EventHandler(this.cbCisloReviru_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Revir :";
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
            this.columnHeaderVaha});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 91);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 351);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeaderPoradie
            // 
            this.columnHeaderPoradie.Text = "Cislo reviru";
            // 
            // columnHeaderDruh
            // 
            this.columnHeaderDruh.Text = "Lokalita";
            // 
            // columnHeaderPocet
            // 
            this.columnHeaderPocet.Text = "Popis";
            this.columnHeaderPocet.Width = 500;
            // 
            // columnHeaderVaha
            // 
            this.columnHeaderVaha.Text = "Gps";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Lokalita :";
            // 
            // txbLokalita
            // 
            this.txbLokalita.Enabled = false;
            this.txbLokalita.Location = new System.Drawing.Point(92, 36);
            this.txbLokalita.Name = "txbLokalita";
            this.txbLokalita.Size = new System.Drawing.Size(100, 20);
            this.txbLokalita.TabIndex = 19;
            // 
            // txbGps
            // 
            this.txbGps.Enabled = false;
            this.txbGps.Location = new System.Drawing.Point(92, 62);
            this.txbGps.Name = "txbGps";
            this.txbGps.Size = new System.Drawing.Size(222, 20);
            this.txbGps.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Gps :";
            // 
            // txbPopis
            // 
            this.txbPopis.Enabled = false;
            this.txbPopis.Location = new System.Drawing.Point(420, 36);
            this.txbPopis.Multiline = true;
            this.txbPopis.Name = "txbPopis";
            this.txbPopis.Size = new System.Drawing.Size(368, 46);
            this.txbPopis.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Popis :";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(420, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 23);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Aktualizovat";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(525, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Ulozit zmeny";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Lokality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txbPopis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbGps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbLokalita);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCisloReviru);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Name = "Lokality";
            this.Text = "Lokality";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCisloReviru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderPoradie;
        private System.Windows.Forms.ColumnHeader columnHeaderDruh;
        private System.Windows.Forms.ColumnHeader columnHeaderPocet;
        private System.Windows.Forms.ColumnHeader columnHeaderVaha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbLokalita;
        private System.Windows.Forms.TextBox txbGps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPopis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
    }
}