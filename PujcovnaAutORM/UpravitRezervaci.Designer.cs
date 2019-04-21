namespace PujcovnaAutORM
{
    partial class UpravitRezervaci
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
            this.vlozitD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datDo = new System.Windows.Forms.DateTimePicker();
            this.DatOd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // vlozitD
            // 
            this.vlozitD.Location = new System.Drawing.Point(92, 146);
            this.vlozitD.Name = "vlozitD";
            this.vlozitD.Size = new System.Drawing.Size(105, 41);
            this.vlozitD.TabIndex = 22;
            this.vlozitD.Text = "Upravit datum";
            this.vlozitD.UseVisualStyleBackColor = true;
            this.vlozitD.Click += new System.EventHandler(this.vlozitD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Datum vrácení";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Datum vyzvednutí";
            // 
            // datDo
            // 
            this.datDo.Location = new System.Drawing.Point(62, 92);
            this.datDo.Name = "datDo";
            this.datDo.Size = new System.Drawing.Size(163, 20);
            this.datDo.TabIndex = 19;
            // 
            // DatOd
            // 
            this.DatOd.Location = new System.Drawing.Point(62, 38);
            this.DatOd.Name = "DatOd";
            this.DatOd.Size = new System.Drawing.Size(163, 20);
            this.DatOd.TabIndex = 18;
            // 
            // UpravitRezervaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 199);
            this.Controls.Add(this.vlozitD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datDo);
            this.Controls.Add(this.DatOd);
            this.Name = "UpravitRezervaci";
            this.Text = "UpravitRezervaci";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button vlozitD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datDo;
        private System.Windows.Forms.DateTimePicker DatOd;
    }
}