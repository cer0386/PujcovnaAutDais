namespace PujcovnaAutORM
{
    partial class NovaRezervace
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
            this.DatOd = new System.Windows.Forms.DateTimePicker();
            this.datDo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cisloRPText = new System.Windows.Forms.TextBox();
            this.pridatZakB = new System.Windows.Forms.Button();
            this.odebratZakB = new System.Windows.Forms.Button();
            this.vytvoritRezB = new System.Windows.Forms.Button();
            this.dostupnaAuta = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.odebratAutoB = new System.Windows.Forms.Button();
            this.pridatAutoB = new System.Windows.Forms.Button();
            this.vlozitD = new System.Windows.Forms.Button();
            this.rekapR = new System.Windows.Forms.ListBox();
            this.novyZak = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dostupnaAuta)).BeginInit();
            this.SuspendLayout();
            // 
            // DatOd
            // 
            this.DatOd.Location = new System.Drawing.Point(12, 40);
            this.DatOd.Name = "DatOd";
            this.DatOd.Size = new System.Drawing.Size(163, 20);
            this.DatOd.TabIndex = 0;
            this.DatOd.ValueChanged += new System.EventHandler(this.DatOd_ValueChanged);
            // 
            // datDo
            // 
            this.datDo.Location = new System.Drawing.Point(12, 94);
            this.datDo.Name = "datDo";
            this.datDo.Size = new System.Drawing.Size(163, 20);
            this.datDo.TabIndex = 1;
            this.datDo.ValueChanged += new System.EventHandler(this.datDo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Datum vyzvednutí";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Datum vrácení";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Číslo řidičského průkazu";
            // 
            // cisloRPText
            // 
            this.cisloRPText.Location = new System.Drawing.Point(12, 202);
            this.cisloRPText.MaxLength = 8;
            this.cisloRPText.Name = "cisloRPText";
            this.cisloRPText.Size = new System.Drawing.Size(163, 20);
            this.cisloRPText.TabIndex = 5;
            // 
            // pridatZakB
            // 
            this.pridatZakB.Location = new System.Drawing.Point(15, 251);
            this.pridatZakB.Name = "pridatZakB";
            this.pridatZakB.Size = new System.Drawing.Size(105, 41);
            this.pridatZakB.TabIndex = 6;
            this.pridatZakB.Text = "Přidat zákazníka";
            this.pridatZakB.UseVisualStyleBackColor = true;
            this.pridatZakB.Click += new System.EventHandler(this.pridatZakB_Click);
            // 
            // odebratZakB
            // 
            this.odebratZakB.Location = new System.Drawing.Point(15, 298);
            this.odebratZakB.Name = "odebratZakB";
            this.odebratZakB.Size = new System.Drawing.Size(105, 41);
            this.odebratZakB.TabIndex = 7;
            this.odebratZakB.Text = "Odebrat zákazníka";
            this.odebratZakB.UseVisualStyleBackColor = true;
            this.odebratZakB.Click += new System.EventHandler(this.odebratZakB_Click);
            // 
            // vytvoritRezB
            // 
            this.vytvoritRezB.Location = new System.Drawing.Point(181, 397);
            this.vytvoritRezB.Name = "vytvoritRezB";
            this.vytvoritRezB.Size = new System.Drawing.Size(80, 41);
            this.vytvoritRezB.TabIndex = 8;
            this.vytvoritRezB.Text = "Vytvořit rezervaci";
            this.vytvoritRezB.UseVisualStyleBackColor = true;
            this.vytvoritRezB.Click += new System.EventHandler(this.vytvoritRezB_Click);
            // 
            // dostupnaAuta
            // 
            this.dostupnaAuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dostupnaAuta.Location = new System.Drawing.Point(363, 40);
            this.dostupnaAuta.Name = "dostupnaAuta";
            this.dostupnaAuta.Size = new System.Drawing.Size(565, 342);
            this.dostupnaAuta.TabIndex = 9;
            this.dostupnaAuta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dostupnaAuta_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Rekapitulace";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Dostupná auta";
            // 
            // odebratAutoB
            // 
            this.odebratAutoB.Location = new System.Drawing.Point(267, 397);
            this.odebratAutoB.Name = "odebratAutoB";
            this.odebratAutoB.Size = new System.Drawing.Size(90, 41);
            this.odebratAutoB.TabIndex = 15;
            this.odebratAutoB.Text = "Odebrat auto";
            this.odebratAutoB.UseVisualStyleBackColor = true;
            this.odebratAutoB.Click += new System.EventHandler(this.odebratAutoB_Click);
            // 
            // pridatAutoB
            // 
            this.pridatAutoB.Location = new System.Drawing.Point(363, 397);
            this.pridatAutoB.Name = "pridatAutoB";
            this.pridatAutoB.Size = new System.Drawing.Size(105, 41);
            this.pridatAutoB.TabIndex = 16;
            this.pridatAutoB.Text = "Přidat auto";
            this.pridatAutoB.UseVisualStyleBackColor = true;
            this.pridatAutoB.Click += new System.EventHandler(this.pridatAutoB_Click);
            // 
            // vlozitD
            // 
            this.vlozitD.Location = new System.Drawing.Point(12, 120);
            this.vlozitD.Name = "vlozitD";
            this.vlozitD.Size = new System.Drawing.Size(105, 41);
            this.vlozitD.TabIndex = 17;
            this.vlozitD.Text = "Vložit datum";
            this.vlozitD.UseVisualStyleBackColor = true;
            this.vlozitD.Click += new System.EventHandler(this.vlozitD_Click);
            // 
            // rekapR
            // 
            this.rekapR.FormattingEnabled = true;
            this.rekapR.Location = new System.Drawing.Point(178, 40);
            this.rekapR.Name = "rekapR";
            this.rekapR.Size = new System.Drawing.Size(179, 342);
            this.rekapR.TabIndex = 19;
            this.rekapR.SelectedIndexChanged += new System.EventHandler(this.rekapR_SelectedIndexChanged);
            // 
            // novyZak
            // 
            this.novyZak.Location = new System.Drawing.Point(12, 397);
            this.novyZak.Name = "novyZak";
            this.novyZak.Size = new System.Drawing.Size(105, 41);
            this.novyZak.TabIndex = 20;
            this.novyZak.Text = "Nový zákazník";
            this.novyZak.UseVisualStyleBackColor = true;
            // 
            // NovaRezervace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 450);
            this.Controls.Add(this.novyZak);
            this.Controls.Add(this.rekapR);
            this.Controls.Add(this.vlozitD);
            this.Controls.Add(this.pridatAutoB);
            this.Controls.Add(this.odebratAutoB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dostupnaAuta);
            this.Controls.Add(this.vytvoritRezB);
            this.Controls.Add(this.odebratZakB);
            this.Controls.Add(this.pridatZakB);
            this.Controls.Add(this.cisloRPText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datDo);
            this.Controls.Add(this.DatOd);
            this.Name = "NovaRezervace";
            this.Text = "NovaRezervace";
            this.Load += new System.EventHandler(this.NovaRezervace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dostupnaAuta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DatOd;
        private System.Windows.Forms.DateTimePicker datDo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cisloRPText;
        private System.Windows.Forms.Button pridatZakB;
        private System.Windows.Forms.Button odebratZakB;
        private System.Windows.Forms.Button vytvoritRezB;
        private System.Windows.Forms.DataGridView dostupnaAuta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button odebratAutoB;
        private System.Windows.Forms.Button pridatAutoB;
        private System.Windows.Forms.Button vlozitD;
        private System.Windows.Forms.ListBox rekapR;
        private System.Windows.Forms.Button novyZak;
    }
}