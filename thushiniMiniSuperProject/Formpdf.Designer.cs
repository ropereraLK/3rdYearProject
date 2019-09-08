namespace thushiniMiniSuperProject
{
    partial class Formpdf
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
            this.xtxtData = new System.Windows.Forms.TextBox();
            this.btnGeneratePDFFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xtxtData
            // 
            this.xtxtData.AcceptsTab = true;
            this.xtxtData.BackColor = System.Drawing.Color.White;
            this.xtxtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xtxtData.Font = new System.Drawing.Font("Arial", 13F);
            this.xtxtData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.xtxtData.Location = new System.Drawing.Point(83, 148);
            this.xtxtData.Multiline = true;
            this.xtxtData.Name = "xtxtData";
            this.xtxtData.Size = new System.Drawing.Size(396, 74);
            this.xtxtData.TabIndex = 12;
            // 
            // btnGeneratePDFFile
            // 
            this.btnGeneratePDFFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.btnGeneratePDFFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.btnGeneratePDFFile.FlatAppearance.BorderSize = 0;
            this.btnGeneratePDFFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.btnGeneratePDFFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.btnGeneratePDFFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePDFFile.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnGeneratePDFFile.ForeColor = System.Drawing.Color.White;
            this.btnGeneratePDFFile.Location = new System.Drawing.Point(117, 337);
            this.btnGeneratePDFFile.Name = "btnGeneratePDFFile";
            this.btnGeneratePDFFile.Size = new System.Drawing.Size(382, 57);
            this.btnGeneratePDFFile.TabIndex = 14;
            this.btnGeneratePDFFile.Text = "Submit";
            this.btnGeneratePDFFile.UseVisualStyleBackColor = false;
            this.btnGeneratePDFFile.Click += new System.EventHandler(this.btnGeneratePDFFile_Click_1);
            // 
            // Formpdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGeneratePDFFile);
            this.Controls.Add(this.xtxtData);
            this.Name = "Formpdf";
            this.Text = "Formpdf";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox xtxtData;
        private System.Windows.Forms.Button btnGeneratePDFFile;
    }
}