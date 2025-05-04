namespace UI
{
    partial class SalesManagementForm
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
            dgvProducts = new Zuby.ADGV.AdvancedDataGridView();
            label1 = new Label();
            btnAddProducts = new Button();
            cmbQuantity = new ComboBox();
            label6 = new Label();
            dgvSelectedProducts = new DataGridView();
            btnRemoveProducts = new Button();
            btnNewSale = new Button();
            label2 = new Label();
            dgvSales = new Zuby.ADGV.AdvancedDataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.FilterAndSortEnabled = true;
            dgvProducts.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            dgvProducts.Location = new Point(12, 32);
            dgvProducts.MaxFilterButtonImageHeight = 23;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RightToLeft = RightToLeft.No;
            dgvProducts.Size = new Size(531, 228);
            dgvProducts.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            dgvProducts.TabIndex = 0;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 1;
            label1.Text = "Productos";
            // 
            // btnAddProducts
            // 
            btnAddProducts.Location = new Point(255, 266);
            btnAddProducts.Name = "btnAddProducts";
            btnAddProducts.Size = new Size(22, 23);
            btnAddProducts.TabIndex = 3;
            btnAddProducts.Text = "⌄";
            btnAddProducts.UseVisualStyleBackColor = true;
            btnAddProducts.Click += btnAddProducts_Click;
            // 
            // cmbQuantity
            // 
            cmbQuantity.FormattingEnabled = true;
            cmbQuantity.Location = new Point(549, 32);
            cmbQuantity.Name = "cmbQuantity";
            cmbQuantity.Size = new Size(55, 23);
            cmbQuantity.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(549, 14);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 12;
            label6.Text = "Cantidad";
            // 
            // dgvSelectedProducts
            // 
            dgvSelectedProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectedProducts.Location = new Point(12, 306);
            dgvSelectedProducts.Name = "dgvSelectedProducts";
            dgvSelectedProducts.Size = new Size(532, 150);
            dgvSelectedProducts.TabIndex = 13;
            dgvSelectedProducts.SelectionChanged += dgvSelectedProducts_SelectionChanged;
            // 
            // btnRemoveProducts
            // 
            btnRemoveProducts.Location = new Point(283, 266);
            btnRemoveProducts.Name = "btnRemoveProducts";
            btnRemoveProducts.Size = new Size(22, 23);
            btnRemoveProducts.TabIndex = 14;
            btnRemoveProducts.Text = "⌃";
            btnRemoveProducts.UseVisualStyleBackColor = true;
            btnRemoveProducts.Click += btnRemoveProducts_Click;
            // 
            // btnNewSale
            // 
            btnNewSale.Location = new Point(237, 471);
            btnNewSale.Name = "btnNewSale";
            btnNewSale.Size = new Size(96, 23);
            btnNewSale.TabIndex = 15;
            btnNewSale.Text = "Nueva Venta";
            btnNewSale.UseVisualStyleBackColor = true;
            btnNewSale.Click += btnNewSale_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 288);
            label2.Name = "label2";
            label2.Size = new Size(138, 15);
            label2.TabIndex = 1;
            label2.Text = "Productos seleccionados";
            // 
            // dgvSales
            // 
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.FilterAndSortEnabled = true;
            dgvSales.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            dgvSales.Location = new Point(666, 32);
            dgvSales.MaxFilterButtonImageHeight = 23;
            dgvSales.Name = "dgvSales";
            dgvSales.RightToLeft = RightToLeft.No;
            dgvSales.Size = new Size(491, 424);
            dgvSales.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            dgvSales.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(666, 14);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 1;
            label3.Text = "Ventas";
            // 
            // SalesManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 590);
            Controls.Add(dgvSales);
            Controls.Add(btnNewSale);
            Controls.Add(btnRemoveProducts);
            Controls.Add(dgvSelectedProducts);
            Controls.Add(label6);
            Controls.Add(cmbQuantity);
            Controls.Add(btnAddProducts);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(dgvProducts);
            Name = "SalesManagementForm";
            Text = "SalesManagementForm";
            Load += SalesManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvProducts;
        private Label label1;
        private Button btnAddProducts;
        private ComboBox cmbQuantity;
        private Label label6;
        private DataGridView dgvSelectedProducts;
        private Button btnRemoveProducts;
        private Button btnNewSale;
        private Label label2;
        private Zuby.ADGV.AdvancedDataGridView dgvSales;
        private Label label3;
    }
}