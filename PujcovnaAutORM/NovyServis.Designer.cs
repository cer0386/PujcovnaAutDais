namespace PujcovnaAutORM
{
    partial class NovyServis
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
            this.spzText = new System.Windows.Forms.TextBox();
            this.datOd = new System.Windows.Forms.DateTimePicker();
            this.datDo = new System.Windows.Forms.DateTimePicker();
            this.servisB = new System.Windows.Forms.Button();
            this.vyraditB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // spzText
            // 
            this.spzText.Location = new System.Drawing.Point(12, 25);
            this.spzText.MaxLength = 7;
            this.spzText.Name = "spzText";
            this.spzText.Size = new System.Drawing.Size(131, 20);
            this.spzText.TabIndex = 0;
            // 
            // datOd
            // 
            this.datOd.Location = new System.Drawing.Point(12, 84);
            this.datOd.Name = "datOd";
            this.datOd.Size = new System.Drawing.Size(200, 20);
            this.datOd.TabIndex = 1;
            // 
            // datDo
            // 
            this.datDo.Location = new System.Drawing.Point(12, 145);
            this.datDo.Name = "datDo";
            this.datDo.Size = new System.Drawing.Size(200, 20);
            this.datDo.TabIndex = 2;
            // 
            // servisB
            // 
            this.servisB.Location = new System.Drawing.Point(12, 182);
            this.servisB.Name = "servisB";
            this.servisB.Size = new System.Drawing.Size(109, 23);
            this.servisB.TabIndex = 3;
            this.servisB.Text = "Dát do servisu";
            this.servisB.UseVisualStyleBackColor = true;
            this.servisB.Click += new System.EventHandler(this.servisB_Click);
            // 
            // vyraditB
            // 
            this.vyraditB.Location = new System.Drawing.Point(196, 22);
            this.vyraditB.Name = "vyraditB";
            this.vyraditB.Size = new System.Drawing.Size(105, 23);
            this.vyraditB.TabIndex = 4;
            this.vyraditB.Text = "Vyřadit auto";
            this.vyraditB.UseVisualStyleBackColor = true;
            this.vyraditB.Click += new System.EventHandler(this.vyraditB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "SPZ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Od";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Do";
            // 
            // NovyServis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 220);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vyraditB);
            this.Controls.Add(this.servisB);
            this.Controls.Add(this.datDo);
            this.Controls.Add(this.datOd);
            this.Controls.Add(this.spzText);
            this.Name = "NovyServis";
            this.Text = "NovyServis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox spzText;
        private System.Windows.Forms.DateTimePicker datOd;
        private System.Windows.Forms.DateTimePicker datDo;
        private System.Windows.Forms.Button servisB;
        private System.Windows.Forms.Button vyraditB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}