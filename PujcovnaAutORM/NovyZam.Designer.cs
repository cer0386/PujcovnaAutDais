namespace PujcovnaAutORM
{
    partial class NovyZam
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
            this.jmeno = new System.Windows.Forms.Label();
            this.novyZamB = new System.Windows.Forms.Button();
            this.jmenoText = new System.Windows.Forms.TextBox();
            this.prijmeniText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.poziceCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // jmeno
            // 
            this.jmeno.AutoSize = true;
            this.jmeno.Location = new System.Drawing.Point(60, 39);
            this.jmeno.Name = "jmeno";
            this.jmeno.Size = new System.Drawing.Size(38, 13);
            this.jmeno.TabIndex = 1;
            this.jmeno.Text = "Jméno";
            // 
            // novyZamB
            // 
            this.novyZamB.Location = new System.Drawing.Point(83, 169);
            this.novyZamB.Name = "novyZamB";
            this.novyZamB.Size = new System.Drawing.Size(75, 23);
            this.novyZamB.TabIndex = 2;
            this.novyZamB.Text = "Vytvořit";
            this.novyZamB.UseVisualStyleBackColor = true;
            this.novyZamB.Click += new System.EventHandler(this.novyZamB_Click);
            // 
            // jmenoText
            // 
            this.jmenoText.Location = new System.Drawing.Point(60, 55);
            this.jmenoText.Name = "jmenoText";
            this.jmenoText.Size = new System.Drawing.Size(124, 20);
            this.jmenoText.TabIndex = 3;
            // 
            // prijmeniText
            // 
            this.prijmeniText.Location = new System.Drawing.Point(60, 100);
            this.prijmeniText.Name = "prijmeniText";
            this.prijmeniText.Size = new System.Drawing.Size(124, 20);
            this.prijmeniText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Příjmení";
            // 
            // poziceCB
            // 
            this.poziceCB.FormattingEnabled = true;
            this.poziceCB.Location = new System.Drawing.Point(63, 142);
            this.poziceCB.Name = "poziceCB";
            this.poziceCB.Size = new System.Drawing.Size(121, 21);
            this.poziceCB.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pozice";
            // 
            // NovyZam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 244);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.poziceCB);
            this.Controls.Add(this.prijmeniText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.jmenoText);
            this.Controls.Add(this.novyZamB);
            this.Controls.Add(this.jmeno);
            this.Name = "NovyZam";
            this.Text = "NovyZam";
            this.Load += new System.EventHandler(this.NovyZam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label jmeno;
        private System.Windows.Forms.Button novyZamB;
        private System.Windows.Forms.TextBox jmenoText;
        private System.Windows.Forms.TextBox prijmeniText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox poziceCB;
        private System.Windows.Forms.Label label1;
    }
}