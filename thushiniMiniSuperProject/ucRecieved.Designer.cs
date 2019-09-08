namespace thushiniMiniSuperProject
{
    partial class ucRecieved
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.btnProductReturn = new System.Windows.Forms.Button();
            this.btnProductRecieve = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(327, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(412, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "DETAILS OF RECEIVED PRODUCTS";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 130);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(967, 359);
            this.dataGridView1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(19, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 23);
            this.label3.TabIndex = 56;
            this.label3.Text = "Supplier";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(23, 80);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(314, 32);
            this.cmbSupplier.TabIndex = 59;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            // 
            // btnProductReturn
            // 
            this.btnProductReturn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnProductReturn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnProductReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnProductReturn.Location = new System.Drawing.Point(472, 497);
            this.btnProductReturn.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductReturn.Name = "btnProductReturn";
            this.btnProductReturn.Size = new System.Drawing.Size(254, 150);
            this.btnProductReturn.TabIndex = 64;
            this.btnProductReturn.Text = "Return Product";
            this.btnProductReturn.UseVisualStyleBackColor = true;
            // 
            // btnProductRecieve
            // 
            this.btnProductRecieve.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnProductRecieve.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnProductRecieve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductRecieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnProductRecieve.Location = new System.Drawing.Point(734, 497);
            this.btnProductRecieve.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductRecieve.Name = "btnProductRecieve";
            this.btnProductRecieve.Size = new System.Drawing.Size(254, 150);
            this.btnProductRecieve.TabIndex = 65;
            this.btnProductRecieve.Text = "Receive Product";
            this.btnProductRecieve.UseVisualStyleBackColor = true;
            this.btnProductRecieve.Click += new System.EventHandler(this.btnProductRecieve_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(820, 67);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(170, 38);
            this.btnRefresh.TabIndex = 66;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ucRecieved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnProductRecieve);
            this.Controls.Add(this.btnProductReturn);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucRecieved";
            this.Size = new System.Drawing.Size(1012, 689);
            this.Load += new System.EventHandler(this.ucRecieved_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnProductReturn;
        private System.Windows.Forms.Button btnProductRecieve;
        private System.Windows.Forms.Button btnRefresh;
    }
}
