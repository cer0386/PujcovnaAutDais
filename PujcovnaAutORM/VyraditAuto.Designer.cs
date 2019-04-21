namespace PujcovnaAutORM
{
    partial class VyraditAuto
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
            this.nahraditB = new System.Windows.Forms.Button();
            this.vyraditB = new System.Windows.Forms.Button();
            this.spzText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hledatB = new System.Windows.Forms.Button();
            this.zaraditB = new System.Windows.Forms.Button();
            this.hledaneAuto = new System.Windows.Forms.DataGridView();
            this.vyrazenaA = new System.Windows.Forms.DataGridView();
            this.autaKVyr = new System.Windows.Forms.DataGridView();
            this.nahradniA = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hledaneAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vyrazenaA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autaKVyr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nahradniA)).BeginInit();
            this.SuspendLayout();
            // 
            // nahraditB
            // 
            this.nahraditB.Location = new System.Drawing.Point(126, 289);
            this.nahraditB.Name = "nahraditB";
            this.nahraditB.Size = new System.Drawing.Size(105, 41);
            this.nahraditB.TabIndex = 11;
            this.nahraditB.Text = "Nahradit";
            this.nahraditB.UseVisualStyleBackColor = true;
            this.nahraditB.Click += new System.EventHandler(this.button2_Click);
            // 
            // vyraditB
            // 
            this.vyraditB.Location = new System.Drawing.Point(4, 289);
            this.vyraditB.Name = "vyraditB";
            this.vyraditB.Size = new System.Drawing.Size(105, 41);
            this.vyraditB.TabIndex = 10;
            this.vyraditB.Text = "Vyřadit";
            this.vyraditB.UseVisualStyleBackColor = true;
            this.vyraditB.Click += new System.EventHandler(this.button1_Click);
            // 
            // spzText
            // 
            this.spzText.Location = new System.Drawing.Point(12, 35);
            this.spzText.MaxLength = 7;
            this.spzText.Name = "spzText";
            this.spzText.Size = new System.Drawing.Size(163, 20);
            this.spzText.TabIndex = 9;
            this.spzText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "SPZ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // hledatB
            // 
            this.hledatB.Location = new System.Drawing.Point(12, 77);
            this.hledatB.Name = "hledatB";
            this.hledatB.Size = new System.Drawing.Size(105, 41);
            this.hledatB.TabIndex = 12;
            this.hledatB.Text = "Vyhledat";
            this.hledatB.UseVisualStyleBackColor = true;
            this.hledatB.Click += new System.EventHandler(this.hledatB_Click);
            // 
            // zaraditB
            // 
            this.zaraditB.Location = new System.Drawing.Point(300, 397);
            this.zaraditB.Name = "zaraditB";
            this.zaraditB.Size = new System.Drawing.Size(105, 41);
            this.zaraditB.TabIndex = 13;
            this.zaraditB.Text = "Zařadit do provozu";
            this.zaraditB.UseVisualStyleBackColor = true;
            this.zaraditB.Click += new System.EventHandler(this.zaraditB_Click);
            // 
            // hledaneAuto
            // 
            this.hledaneAuto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hledaneAuto.Location = new System.Drawing.Point(4, 133);
            this.hledaneAuto.Name = "hledaneAuto";
            this.hledaneAuto.Size = new System.Drawing.Size(227, 150);
            this.hledaneAuto.TabIndex = 14;
            // 
            // vyrazenaA
            // 
            this.vyrazenaA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vyrazenaA.Location = new System.Drawing.Point(237, 35);
            this.vyrazenaA.Name = "vyrazenaA";
            this.vyrazenaA.Size = new System.Drawing.Size(263, 356);
            this.vyrazenaA.TabIndex = 15;
            this.vyrazenaA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vyrazenaA_CellContentClick);
            this.vyrazenaA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vyrazenaA_CellClick);
            // 
            // autaKVyr
            // 
            this.autaKVyr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.autaKVyr.Location = new System.Drawing.Point(506, 35);
            this.autaKVyr.Name = "autaKVyr";
            this.autaKVyr.Size = new System.Drawing.Size(263, 403);
            this.autaKVyr.TabIndex = 16;
            // 
            // nahradniA
            // 
            this.nahradniA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nahradniA.Location = new System.Drawing.Point(775, 35);
            this.nahradniA.Name = "nahradniA";
            this.nahradniA.Size = new System.Drawing.Size(263, 403);
            this.nahradniA.TabIndex = 17;
            this.nahradniA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.nahradniA_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Vyřazená auta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Auta k vyřazení";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(772, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Náhradní auta";
            // 
            // VyraditAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nahradniA);
            this.Controls.Add(this.autaKVyr);
            this.Controls.Add(this.vyrazenaA);
            this.Controls.Add(this.hledaneAuto);
            this.Controls.Add(this.zaraditB);
            this.Controls.Add(this.hledatB);
            this.Controls.Add(this.nahraditB);
            this.Controls.Add(this.vyraditB);
            this.Controls.Add(this.spzText);
            this.Controls.Add(this.label3);
            this.Name = "VyraditAuto";
            this.Text = "VyraditAuto";
            this.Load += new System.EventHandler(this.VyraditAuto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hledaneAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vyrazenaA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autaKVyr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nahradniA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nahraditB;
        private System.Windows.Forms.Button vyraditB;
        private System.Windows.Forms.TextBox spzText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button hledatB;
        private System.Windows.Forms.Button zaraditB;
        private System.Windows.Forms.DataGridView hledaneAuto;
        private System.Windows.Forms.DataGridView vyrazenaA;
        private System.Windows.Forms.DataGridView autaKVyr;
        private System.Windows.Forms.DataGridView nahradniA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}