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
            cmbPaymentMethods = new ComboBox();
            cmbPaymentMethod = new Label();
            txtTicketNumber = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtInvoiceNumber = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            cmbCustomer = new ComboBox();
            label5 = new Label();
            cmbQuantity = new ComboBox();
            label6 = new Label();
            dgvSelectedProducts = new DataGridView();
            btnRemoveProducts = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedProducts).BeginInit();
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
            dgvProducts.Size = new Size(531, 197);
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
            btnAddProducts.Location = new Point(257, 235);
            btnAddProducts.Name = "btnAddProducts";
            btnAddProducts.Size = new Size(22, 23);
            btnAddProducts.TabIndex = 3;
            btnAddProducts.Text = "⌄";
            btnAddProducts.UseVisualStyleBackColor = true;
            btnAddProducts.Click += btnAddProducts_Click;
            // 
            // cmbPaymentMethods
            // 
            cmbPaymentMethods.FormattingEnabled = true;
            cmbPaymentMethods.Location = new Point(706, 88);
            cmbPaymentMethods.Name = "cmbPaymentMethods";
            cmbPaymentMethods.Size = new Size(150, 23);
            cmbPaymentMethods.TabIndex = 4;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.AutoSize = true;
            cmbPaymentMethod.Location = new Point(706, 70);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(95, 15);
            cmbPaymentMethod.TabIndex = 5;
            cmbPaymentMethod.Text = "Metodo de pago";
            // 
            // txtTicketNumber
            // 
            txtTicketNumber.Location = new Point(706, 308);
            txtTicketNumber.Name = "txtTicketNumber";
            txtTicketNumber.Size = new Size(150, 23);
            txtTicketNumber.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(706, 290);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 7;
            label2.Text = "Número de ticket";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(706, 345);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 9;
            label3.Text = "Número de factura";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(706, 363);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new Size(150, 23);
            txtInvoiceNumber.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(706, 174);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 95);
            textBox1.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(706, 156);
            label4.Name = "label4";
            label4.Size = new Size(150, 15);
            label4.TabIndex = 5;
            label4.Text = "Detalle de metodo de pago";
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(706, 36);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(150, 23);
            cmbCustomer.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(706, 18);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 5;
            label5.Text = "Cliente";
            // 
            // cmbQuantity
            // 
            cmbQuantity.FormattingEnabled = true;
            cmbQuantity.Location = new Point(549, 49);
            cmbQuantity.Name = "cmbQuantity";
            cmbQuantity.Size = new Size(77, 23);
            cmbQuantity.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(549, 31);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 12;
            label6.Text = "Cantidad";
            // 
            // dgvSelectedProducts
            // 
            dgvSelectedProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectedProducts.Location = new Point(11, 277);
            dgvSelectedProducts.Name = "dgvSelectedProducts";
            dgvSelectedProducts.Size = new Size(532, 150);
            dgvSelectedProducts.TabIndex = 13;
            dgvSelectedProducts.SelectionChanged += dgvSelectedProducts_SelectionChanged;
            // 
            // btnRemoveProducts
            // 
            btnRemoveProducts.Location = new Point(285, 235);
            btnRemoveProducts.Name = "btnRemoveProducts";
            btnRemoveProducts.Size = new Size(22, 23);
            btnRemoveProducts.TabIndex = 14;
            btnRemoveProducts.Text = "⌃";
            btnRemoveProducts.UseVisualStyleBackColor = true;
            btnRemoveProducts.Click += btnRemoveProducts_Click;
            // 
            // SalesManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 590);
            Controls.Add(btnRemoveProducts);
            Controls.Add(dgvSelectedProducts);
            Controls.Add(label6);
            Controls.Add(cmbQuantity);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(txtInvoiceNumber);
            Controls.Add(label2);
            Controls.Add(txtTicketNumber);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(cmbCustomer);
            Controls.Add(cmbPaymentMethods);
            Controls.Add(btnAddProducts);
            Controls.Add(label1);
            Controls.Add(dgvProducts);
            Name = "SalesManagementForm";
            Text = "SalesManagementForm";
            Load += SalesManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvProducts;
        private Label label1;
        private Button btnAddProducts;
        private ComboBox cmbPaymentMethods;
        private Label cmbPaymentMethod;
        private TextBox txtTicketNumber;
        private Label label2;
        private Label label3;
        private TextBox txtInvoiceNumber;
        private TextBox textBox1;
        private Label label4;
        private ComboBox cmbCustomer;
        private Label label5;
        private ComboBox cmbQuantity;
        private Label label6;
        private DataGridView dgvSelectedProducts;
        private Button btnRemoveProducts;
    }
}