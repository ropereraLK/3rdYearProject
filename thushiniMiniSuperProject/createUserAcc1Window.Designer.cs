namespace thushiniMiniSuperProject
{
    partial class createUserAcc1Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createUserAcc1Window));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.pbUserNameCorrect = new System.Windows.Forms.PictureBox();
            this.pbPassCorrect = new System.Windows.Forms.PictureBox();
            this.pbConfirmCorrect = new System.Windows.Forms.PictureBox();
            this.pcUsernameWrong = new System.Windows.Forms.PictureBox();
            this.pcConfirmWrong = new System.Windows.Forms.PictureBox();
            this.pcPasswordWrong = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserNameCorrect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassCorrect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmCorrect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcUsernameWrong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcConfirmWrong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPasswordWrong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(454, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "CREATE YOUR ACCOUNT";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 723);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.btnSignIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.btnSignIn.FlatAppearance.BorderSize = 0;
            this.btnSignIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.btnSignIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(405, 534);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(382, 57);
            this.btnSignIn.TabIndex = 13;
            this.btnSignIn.Text = "Create";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(496, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(496, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 13F);
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPassword.Location = new System.Drawing.Point(493, 258);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(220, 32);
            this.txtPassword.TabIndex = 15;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // txtUsername
            // 
            this.txtUsername.AcceptsTab = true;
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Arial", 13F);
            this.txtUsername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtUsername.Location = new System.Drawing.Point(493, 178);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(220, 32);
            this.txtUsername.TabIndex = 14;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label4.Location = new System.Drawing.Point(496, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "Re-enter Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Arial", 13F);
            this.txtConfirmPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtConfirmPassword.Location = new System.Drawing.Point(493, 342);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(220, 32);
            this.txtConfirmPassword.TabIndex = 18;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            this.txtConfirmPassword.Enter += new System.EventHandler(this.txtConfirmPassword_Enter);
            // 
            // pbUserNameCorrect
            // 
            this.pbUserNameCorrect.Image = ((System.Drawing.Image)(resources.GetObject("pbUserNameCorrect.Image")));
            this.pbUserNameCorrect.Location = new System.Drawing.Point(725, 169);
            this.pbUserNameCorrect.Name = "pbUserNameCorrect";
            this.pbUserNameCorrect.Size = new System.Drawing.Size(40, 40);
            this.pbUserNameCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUserNameCorrect.TabIndex = 20;
            this.pbUserNameCorrect.TabStop = false;
            this.pbUserNameCorrect.Visible = false;
            // 
            // pbPassCorrect
            // 
            this.pbPassCorrect.Image = ((System.Drawing.Image)(resources.GetObject("pbPassCorrect.Image")));
            this.pbPassCorrect.Location = new System.Drawing.Point(725, 253);
            this.pbPassCorrect.Name = "pbPassCorrect";
            this.pbPassCorrect.Size = new System.Drawing.Size(40, 40);
            this.pbPassCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPassCorrect.TabIndex = 21;
            this.pbPassCorrect.TabStop = false;
            this.pbPassCorrect.Visible = false;
            // 
            // pbConfirmCorrect
            // 
            this.pbConfirmCorrect.Image = ((System.Drawing.Image)(resources.GetObject("pbConfirmCorrect.Image")));
            this.pbConfirmCorrect.Location = new System.Drawing.Point(725, 337);
            this.pbConfirmCorrect.Name = "pbConfirmCorrect";
            this.pbConfirmCorrect.Size = new System.Drawing.Size(40, 40);
            this.pbConfirmCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbConfirmCorrect.TabIndex = 22;
            this.pbConfirmCorrect.TabStop = false;
            this.pbConfirmCorrect.Visible = false;
            // 
            // pcUsernameWrong
            // 
            this.pcUsernameWrong.Image = ((System.Drawing.Image)(resources.GetObject("pcUsernameWrong.Image")));
            this.pcUsernameWrong.Location = new System.Drawing.Point(730, 176);
            this.pcUsernameWrong.Name = "pcUsernameWrong";
            this.pcUsernameWrong.Size = new System.Drawing.Size(29, 27);
            this.pcUsernameWrong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcUsernameWrong.TabIndex = 23;
            this.pcUsernameWrong.TabStop = false;
            this.pcUsernameWrong.Visible = false;
            // 
            // pcConfirmWrong
            // 
            this.pcConfirmWrong.Image = ((System.Drawing.Image)(resources.GetObject("pcConfirmWrong.Image")));
            this.pcConfirmWrong.Location = new System.Drawing.Point(731, 343);
            this.pcConfirmWrong.Name = "pcConfirmWrong";
            this.pcConfirmWrong.Size = new System.Drawing.Size(29, 27);
            this.pcConfirmWrong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcConfirmWrong.TabIndex = 26;
            this.pcConfirmWrong.TabStop = false;
            this.pcConfirmWrong.Visible = false;
            // 
            // pcPasswordWrong
            // 
            this.pcPasswordWrong.Image = ((System.Drawing.Image)(resources.GetObject("pcPasswordWrong.Image")));
            this.pcPasswordWrong.Location = new System.Drawing.Point(730, 260);
            this.pcPasswordWrong.Name = "pcPasswordWrong";
            this.pcPasswordWrong.Size = new System.Drawing.Size(29, 27);
            this.pcPasswordWrong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcPasswordWrong.TabIndex = 27;
            this.pcPasswordWrong.TabStop = false;
            this.pcPasswordWrong.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(67)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(405, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(382, 57);
            this.button1.TabIndex = 28;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // createUserAcc1Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1154, 720);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pcPasswordWrong);
            this.Controls.Add(this.pcConfirmWrong);
            this.Controls.Add(this.pcUsernameWrong);
            this.Controls.Add(this.pbConfirmCorrect);
            this.Controls.Add(this.pbPassCorrect);
            this.Controls.Add(this.pbUserNameCorrect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "createUserAcc1Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "createUserAcc1Window";
            this.Load += new System.EventHandler(this.createUserAcc1Window_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserNameCorrect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassCorrect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmCorrect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcUsernameWrong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcConfirmWrong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPasswordWrong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.PictureBox pbUserNameCorrect;
        private System.Windows.Forms.PictureBox pbPassCorrect;
        private System.Windows.Forms.PictureBox pbConfirmCorrect;
        private System.Windows.Forms.PictureBox pcUsernameWrong;
        private System.Windows.Forms.PictureBox pcConfirmWrong;
        private System.Windows.Forms.PictureBox pcPasswordWrong;
        private System.Windows.Forms.Button button1;
    }
}