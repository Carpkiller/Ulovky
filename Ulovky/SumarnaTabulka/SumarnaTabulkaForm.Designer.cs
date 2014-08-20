namespace Ulovky.SumarnaTabulka
{
    partial class SumarnaTabulkaFrom
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
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(406, 104);
            this.listView1.TabIndex = 0;
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
            // SumarnaTabulkaFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 127);
            this.Controls.Add(this.listView1);
            this.Name = "SumarnaTabulkaFrom";
            this.Text = "SumarnaTabulka";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderPoradie;
        private System.Windows.Forms.ColumnHeader columnHeaderDruh;
        private System.Windows.Forms.ColumnHeader columnHeaderPocet;
        private System.Windows.Forms.ColumnHeader columnHeaderVaha;
        private System.Windows.Forms.ColumnHeader columnHeaderPriemer;
    }
}