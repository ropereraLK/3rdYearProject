namespace thushiniMiniSuperProject
{
    partial class msgProfileCreated
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(msgProfileCreated));
            this.pbUserNameCorrect = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserNameCorrect)).BeginInit();
            this.SuspendLayout();
            // 
            // pbUserNameCorrect
            // 
            this.pbUserNameCorrect.Image = ((System.Drawing.Image)(resources.GetObject("pbUserNameCorrect.Image")));
            this.pbUserNameCorrect.Location = new System.Drawing.Point(100, 75);
            this.pbUserNameCorrect.Name = "pbUserNameCorrect";
            this.pbUserNameCorrect.Size = new System.Drawing.Size(200, 200);
            this.pbUserNameCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUserNameCorrect.TabIndex = 21;
            this.pbUserNameCorrect.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(61, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "Profile Created Successfully";
            // 
            // msgProfileCreated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbUserNameCorrect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "msgProfileCreated";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "msgProfileCreated";
            ((System.ComponentModel.ISupportInitialize)(this.pbUserNameCorrect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbUserNameCorrect;
        private System.Windows.Forms.Label label3;
    }
}