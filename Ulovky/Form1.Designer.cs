namespace Ulovky
{
    partial class Form1
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
            this.columnHeaderDatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCisloReviru = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMiesto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLokalita = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPoradie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDruh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDlzka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVaha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSposobLovu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNastraha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPustena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPoznamky = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prihlasenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabulkyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koncorocnaTabulkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabulkaTopUlovkovToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.celkovaTabulkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPredch = new System.Windows.Forms.Button();
            this.buttonNasled = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDatum,
            this.columnHeaderCisloReviru,
            this.columnHeaderMiesto,
            this.columnHeaderLokalita,
            this.columnHeaderPoradie,
            this.columnHeaderDruh,
            this.columnHeaderDlzka,
            this.columnHeaderVaha,
            this.columnHeaderSposobLovu,
            this.columnHeaderNastraha,
            this.columnHeaderPustena,
            this.columnHeaderPoznamky});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 69);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1107, 512);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderDatum
            // 
            this.columnHeaderDatum.Text = "Datum";
            this.columnHeaderDatum.Width = 25;
            // 
            // columnHeaderCisloReviru
            // 
            this.columnHeaderCisloReviru.Text = "Cislo reviru";
            this.columnHeaderCisloReviru.Width = 25;
            // 
            // columnHeaderMiesto
            // 
            this.columnHeaderMiesto.Text = "Nazov reviru";
            this.columnHeaderMiesto.Width = 25;
            // 
            // columnHeaderLokalita
            // 
            this.columnHeaderLokalita.Text = "Lokalita";
            this.columnHeaderLokalita.Width = 25;
            // 
            // columnHeaderPoradie
            // 
            this.columnHeaderPoradie.Text = "Poradie";
            // 
            // columnHeaderDruh
            // 
            this.columnHeaderDruh.Text = "Druh";
            this.columnHeaderDruh.Width = 25;
            // 
            // columnHeaderDlzka
            // 
            this.columnHeaderDlzka.Text = "Dlazka";
            this.columnHeaderDlzka.Width = 25;
            // 
            // columnHeaderVaha
            // 
            this.columnHeaderVaha.Text = "Vaha";
            this.columnHeaderVaha.Width = 25;
            // 
            // columnHeaderSposobLovu
            // 
            this.columnHeaderSposobLovu.Text = "Sposob lovu";
            this.columnHeaderSposobLovu.Width = 25;
            // 
            // columnHeaderNastraha
            // 
            this.columnHeaderNastraha.Text = "Nastraha";
            this.columnHeaderNastraha.Width = 25;
            // 
            // columnHeaderPustena
            // 
            this.columnHeaderPustena.Text = "Pustena";
            this.columnHeaderPustena.Width = 25;
            // 
            // columnHeaderPoznamky
            // 
            this.columnHeaderPoznamky.Text = "Poznamky";
            this.columnHeaderPoznamky.Width = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Pridanie zaznamu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(133, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Editacia zaznamu";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(254, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Odobratie zaznamu";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.tabulkyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1131, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prihlasenieToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // prihlasenieToolStripMenuItem
            // 
            this.prihlasenieToolStripMenuItem.Name = "prihlasenieToolStripMenuItem";
            this.prihlasenieToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.prihlasenieToolStripMenuItem.Text = "Prihlasenie";
            this.prihlasenieToolStripMenuItem.Click += new System.EventHandler(this.prihlasenieToolStripMenuItem_Click);
            // 
            // tabulkyToolStripMenuItem
            // 
            this.tabulkyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.koncorocnaTabulkaToolStripMenuItem,
            this.tabulkaTopUlovkovToolStripMenuItem,
            this.celkovaTabulkaToolStripMenuItem});
            this.tabulkyToolStripMenuItem.Name = "tabulkyToolStripMenuItem";
            this.tabulkyToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.tabulkyToolStripMenuItem.Text = "Tabulky";
            // 
            // koncorocnaTabulkaToolStripMenuItem
            // 
            this.koncorocnaTabulkaToolStripMenuItem.Name = "koncorocnaTabulkaToolStripMenuItem";
            this.koncorocnaTabulkaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.koncorocnaTabulkaToolStripMenuItem.Text = "Koncorocna tabulka";
            this.koncorocnaTabulkaToolStripMenuItem.Click += new System.EventHandler(this.koncorocnaTabulkaToolStripMenuItem_Click);
            // 
            // tabulkaTopUlovkovToolStripMenuItem
            // 
            this.tabulkaTopUlovkovToolStripMenuItem.Name = "tabulkaTopUlovkovToolStripMenuItem";
            this.tabulkaTopUlovkovToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.tabulkaTopUlovkovToolStripMenuItem.Text = "Tabulka top ulovkov";
            // 
            // celkovaTabulkaToolStripMenuItem
            // 
            this.celkovaTabulkaToolStripMenuItem.Name = "celkovaTabulkaToolStripMenuItem";
            this.celkovaTabulkaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.celkovaTabulkaToolStripMenuItem.Text = "Celkova tabulka";
            // 
            // buttonPredch
            // 
            this.buttonPredch.Location = new System.Drawing.Point(931, 40);
            this.buttonPredch.Name = "buttonPredch";
            this.buttonPredch.Size = new System.Drawing.Size(75, 23);
            this.buttonPredch.TabIndex = 5;
            this.buttonPredch.UseVisualStyleBackColor = true;
            this.buttonPredch.Click += new System.EventHandler(this.buttonPredch_Click);
            // 
            // buttonNasled
            // 
            this.buttonNasled.Location = new System.Drawing.Point(1045, 40);
            this.buttonNasled.Name = "buttonNasled";
            this.buttonNasled.Size = new System.Drawing.Size(75, 23);
            this.buttonNasled.TabIndex = 6;
            this.buttonNasled.UseVisualStyleBackColor = true;
            this.buttonNasled.Click += new System.EventHandler(this.buttonNasled_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 593);
            this.Controls.Add(this.buttonNasled);
            this.Controls.Add(this.buttonPredch);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Ulovky";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prihlasenieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabulkyToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderDatum;
        private System.Windows.Forms.ColumnHeader columnHeaderMiesto;
        private System.Windows.Forms.ColumnHeader columnHeaderDruh;
        private System.Windows.Forms.ColumnHeader columnHeaderDlzka;
        private System.Windows.Forms.ColumnHeader columnHeaderVaha;
        private System.Windows.Forms.ColumnHeader columnHeaderSposobLovu;
        private System.Windows.Forms.ColumnHeader columnHeaderNastraha;
        private System.Windows.Forms.ColumnHeader columnHeaderCisloReviru;
        private System.Windows.Forms.ColumnHeader columnHeaderLokalita;
        private System.Windows.Forms.ColumnHeader columnHeaderPustena;
        private System.Windows.Forms.ColumnHeader columnHeaderPoznamky;
        private System.Windows.Forms.ToolStripMenuItem koncorocnaTabulkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabulkaTopUlovkovToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem celkovaTabulkaToolStripMenuItem;
        private System.Windows.Forms.Button buttonPredch;
        private System.Windows.Forms.Button buttonNasled;
        private System.Windows.Forms.ColumnHeader columnHeaderPoradie;
    }
}

