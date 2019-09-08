namespace thushiniMiniSuperProject
{
    partial class ucProducts
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
            this.btnAddProducts = new System.Windows.Forms.Button();
            this.btnUpdateProducts = new System.Windows.Forms.Button();
            this.btnProductPurchase = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chbStatus = new System.Windows.Forms.CheckBox();
            this.chbStockinRisk = new System.Windows.Forms.CheckBox();
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
            this.label2.Size = new System.Drawing.Size(289, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "DETAILS OF PRODUCTS";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(23, 130);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(967, 359);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnAddProducts
            // 
            this.btnAddProducts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnAddProducts.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAddProducts.Location = new System.Drawing.Point(453, 503);
            this.btnAddProducts.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProducts.Name = "btnAddProducts";
            this.btnAddProducts.Size = new System.Drawing.Size(254, 150);
            this.btnAddProducts.TabIndex = 7;
            this.btnAddProducts.Text = "Add Product";
            this.btnAddProducts.UseVisualStyleBackColor = true;
            this.btnAddProducts.Click += new System.EventHandler(this.btnAddProducts_Click);
            // 
            // btnUpdateProducts
            // 
            this.btnUpdateProducts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnUpdateProducts.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdateProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnUpdateProducts.Location = new System.Drawing.Point(34, 503);
            this.btnUpdateProducts.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateProducts.Name = "btnUpdateProducts";
            this.btnUpdateProducts.Size = new System.Drawing.Size(254, 150);
            this.btnUpdateProducts.TabIndex = 8;
            this.btnUpdateProducts.Text = "Update Product";
            this.btnUpdateProducts.UseVisualStyleBackColor = true;
            this.btnUpdateProducts.Click += new System.EventHandler(this.btnUpdateProducts_Click);
            // 
            // btnProductPurchase
            // 
            this.btnProductPurchase.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnProductPurchase.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnProductPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnProductPurchase.Location = new System.Drawing.Point(736, 502);
            this.btnProductPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductPurchase.Name = "btnProductPurchase";
            this.btnProductPurchase.Size = new System.Drawing.Size(254, 150);
            this.btnProductPurchase.TabIndex = 9;
            this.btnProductPurchase.Text = "Purchases Order";
            this.btnProductPurchase.UseVisualStyleBackColor = true;
            this.btnProductPurchase.Click += new System.EventHandler(this.btnProductPurchase_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label5.Location = new System.Drawing.Point(19, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 50;
            this.label5.Text = "Supplier";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(23, 71);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(337, 32);
            this.cmbSupplier.TabIndex = 53;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
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
            this.btnRefresh.TabIndex = 54;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chbStatus
            // 
            this.chbStatus.AutoSize = true;
            this.chbStatus.Font = new System.Drawing.Font("Arial", 12F);
            this.chbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.chbStatus.Location = new System.Drawing.Point(408, 76);
            this.chbStatus.Name = "chbStatus";
            this.chbStatus.Size = new System.Drawing.Size(144, 27);
            this.chbStatus.TabIndex = 55;
            this.chbStatus.Text = "Empty Stock";
            this.chbStatus.UseVisualStyleBackColor = true;
            this.chbStatus.CheckedChanged += new System.EventHandler(this.chbStatus_CheckedChanged);
            // 
            // chbStockinRisk
            // 
            this.chbStockinRisk.AutoSize = true;
            this.chbStockinRisk.Font = new System.Drawing.Font("Arial", 12F);
            this.chbStockinRisk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.chbStockinRisk.Location = new System.Drawing.Point(573, 78);
            this.chbStockinRisk.Name = "chbStockinRisk";
            this.chbStockinRisk.Size = new System.Drawing.Size(146, 27);
            this.chbStockinRisk.TabIndex = 56;
            this.chbStockinRisk.Text = "Stock in Risk";
            this.chbStockinRisk.UseVisualStyleBackColor = true;
            this.chbStockinRisk.CheckedChanged += new System.EventHandler(this.chbStockinRisk_CheckedChanged);
            // 
            // ucProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chbStockinRisk);
            this.Controls.Add(this.chbStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnProductPurchase);
            this.Controls.Add(this.btnUpdateProducts);
            this.Controls.Add(this.btnAddProducts);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucProducts";
            this.Size = new System.Drawing.Size(1012, 689);
            this.Load += new System.EventHandler(this.ucProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddProducts;
        private System.Windows.Forms.Button btnUpdateProducts;
        private System.Windows.Forms.Button btnProductPurchase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.CheckBox chbStatus;
        public System.Windows.Forms.CheckBox chbStockinRisk;
    }
}
