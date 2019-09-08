namespace thushiniMiniSuperProject
{
    partial class invPurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(invPurchaseOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExpectedIncome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrossProfit = new System.Windows.Forms.TextBox();
            this.txtOrdervalue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProducts = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnPO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 954);
            this.panel1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(189, 130);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1127, 371);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(526, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 29);
            this.label1.TabIndex = 42;
            this.label1.Text = "PURCHASE ORDER MANAGEMENT PORTAL";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.BackColor = System.Drawing.Color.White;
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.cmbSupplier.Items.AddRange(new object[] {
            "--Select--"});
            this.cmbSupplier.Location = new System.Drawing.Point(189, 91);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(350, 32);
            this.cmbSupplier.TabIndex = 61;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(185, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 55;
            this.label2.Text = "Supplier";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(678, 661);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 57);
            this.button1.TabIndex = 65;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.btnOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.btnOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(934, 661);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(382, 57);
            this.btnOrder.TabIndex = 64;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label6.Location = new System.Drawing.Point(1039, 586);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 23);
            this.label6.TabIndex = 69;
            this.label6.Text = "Gross Profit";
            this.label6.Visible = false;
            // 
            // txtExpectedIncome
            // 
            this.txtExpectedIncome.AcceptsTab = true;
            this.txtExpectedIncome.BackColor = System.Drawing.Color.White;
            this.txtExpectedIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpectedIncome.Enabled = false;
            this.txtExpectedIncome.Font = new System.Drawing.Font("Arial", 12F);
            this.txtExpectedIncome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtExpectedIncome.Location = new System.Drawing.Point(1164, 548);
            this.txtExpectedIncome.Margin = new System.Windows.Forms.Padding(4);
            this.txtExpectedIncome.Name = "txtExpectedIncome";
            this.txtExpectedIncome.Size = new System.Drawing.Size(152, 30);
            this.txtExpectedIncome.TabIndex = 68;
            this.txtExpectedIncome.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label7.Location = new System.Drawing.Point(1040, 510);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 23);
            this.label7.TabIndex = 71;
            this.label7.Text = "Order Value";
            // 
            // txtGrossProfit
            // 
            this.txtGrossProfit.AcceptsTab = true;
            this.txtGrossProfit.BackColor = System.Drawing.Color.White;
            this.txtGrossProfit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrossProfit.Enabled = false;
            this.txtGrossProfit.Font = new System.Drawing.Font("Arial", 12F);
            this.txtGrossProfit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtGrossProfit.Location = new System.Drawing.Point(1164, 586);
            this.txtGrossProfit.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrossProfit.Name = "txtGrossProfit";
            this.txtGrossProfit.Size = new System.Drawing.Size(152, 30);
            this.txtGrossProfit.TabIndex = 70;
            this.txtGrossProfit.Visible = false;
            // 
            // txtOrdervalue
            // 
            this.txtOrdervalue.AcceptsTab = true;
            this.txtOrdervalue.BackColor = System.Drawing.Color.White;
            this.txtOrdervalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrdervalue.Enabled = false;
            this.txtOrdervalue.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrdervalue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtOrdervalue.Location = new System.Drawing.Point(1164, 510);
            this.txtOrdervalue.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrdervalue.Name = "txtOrdervalue";
            this.txtOrdervalue.Size = new System.Drawing.Size(152, 30);
            this.txtOrdervalue.TabIndex = 72;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label8.Location = new System.Drawing.Point(1005, 548);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 23);
            this.label8.TabIndex = 73;
            this.label8.Text = "Expected Income";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label9.Location = new System.Drawing.Point(704, 548);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 79;
            this.label9.Text = "#Units";
            // 
            // txtProducts
            // 
            this.txtProducts.AcceptsTab = true;
            this.txtProducts.BackColor = System.Drawing.Color.White;
            this.txtProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProducts.Enabled = false;
            this.txtProducts.Font = new System.Drawing.Font("Arial", 12F);
            this.txtProducts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtProducts.Location = new System.Drawing.Point(781, 510);
            this.txtProducts.Margin = new System.Windows.Forms.Padding(4);
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.Size = new System.Drawing.Size(152, 30);
            this.txtProducts.TabIndex = 78;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label10.Location = new System.Drawing.Point(674, 510);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 23);
            this.label10.TabIndex = 77;
            this.label10.Text = "#Products";
            // 
            // txtUnits
            // 
            this.txtUnits.AcceptsTab = true;
            this.txtUnits.BackColor = System.Drawing.Color.White;
            this.txtUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnits.Enabled = false;
            this.txtUnits.Font = new System.Drawing.Font("Arial", 12F);
            this.txtUnits.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtUnits.Location = new System.Drawing.Point(781, 548);
            this.txtUnits.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(152, 30);
            this.txtUnits.TabIndex = 74;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label12.Location = new System.Drawing.Point(260, 510);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 23);
            this.label12.TabIndex = 80;
            this.label12.Text = "Expected Day";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.LightGreen;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.dateTimePicker1.CausesValidation = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(397, 511);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker1.TabIndex = 84;
            this.dateTimePicker1.Value = new System.DateTime(2019, 8, 28, 2, 52, 0, 0);
            // 
            // btnPO
            // 
            this.btnPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.btnPO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(67)))));
            this.btnPO.FlatAppearance.BorderSize = 0;
            this.btnPO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.btnPO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(84)))));
            this.btnPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPO.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnPO.ForeColor = System.Drawing.Color.White;
            this.btnPO.Location = new System.Drawing.Point(934, 661);
            this.btnPO.Name = "btnPO";
            this.btnPO.Size = new System.Drawing.Size(382, 57);
            this.btnPO.TabIndex = 85;
            this.btnPO.Text = "Generate Purchase Order";
            this.btnPO.UseVisualStyleBackColor = false;
            this.btnPO.Click += new System.EventHandler(this.btnPO_Click);
            // 
            // invPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1400, 740);
            this.Controls.Add(this.btnPO);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtProducts);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtUnits);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtOrdervalue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGrossProfit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtExpectedIncome);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "invPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "invPurchaseOrder";
            this.Load += new System.EventHandler(this.invPurchaseOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExpectedIncome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrossProfit;
        private System.Windows.Forms.TextBox txtOrdervalue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProducts;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnPO;
    }
}