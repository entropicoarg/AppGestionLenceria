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
            advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            label1 = new Label();
            advancedDataGridView2 = new Zuby.ADGV.AdvancedDataGridView();
            btnAddProducts = new Button();
            comboBox1 = new ComboBox();
            cmbPaymentMethod = new Label();
            txtTicketNumber = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtInvoiceNumber = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            cmbCustomer = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)advancedDataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)advancedDataGridView2).BeginInit();
            SuspendLayout();
            // 
            // advancedDataGridView1
            // 
            advancedDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            advancedDataGridView1.FilterAndSortEnabled = true;
            advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            advancedDataGridView1.Location = new Point(12, 32);
            advancedDataGridView1.MaxFilterButtonImageHeight = 23;
            advancedDataGridView1.Name = "advancedDataGridView1";
            advancedDataGridView1.RightToLeft = RightToLeft.No;
            advancedDataGridView1.Size = new Size(531, 197);
            advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            advancedDataGridView1.TabIndex = 0;
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
            // advancedDataGridView2
            // 
            advancedDataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            advancedDataGridView2.FilterAndSortEnabled = true;
            advancedDataGridView2.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            advancedDataGridView2.Location = new Point(12, 264);
            advancedDataGridView2.MaxFilterButtonImageHeight = 23;
            advancedDataGridView2.Name = "advancedDataGridView2";
            advancedDataGridView2.RightToLeft = RightToLeft.No;
            advancedDataGridView2.Size = new Size(531, 117);
            advancedDataGridView2.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            advancedDataGridView2.TabIndex = 2;
            // 
            // btnAddProducts
            // 
            btnAddProducts.Location = new Point(257, 235);
            btnAddProducts.Name = "btnAddProducts";
            btnAddProducts.Size = new Size(22, 23);
            btnAddProducts.TabIndex = 3;
            btnAddProducts.Text = ">";
            btnAddProducts.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(631, 102);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 23);
            comboBox1.TabIndex = 4;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.AutoSize = true;
            cmbPaymentMethod.Location = new Point(631, 84);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(95, 15);
            cmbPaymentMethod.TabIndex = 5;
            cmbPaymentMethod.Text = "Metodo de pago";
            // 
            // txtTicketNumber
            // 
            txtTicketNumber.Location = new Point(631, 322);
            txtTicketNumber.Name = "txtTicketNumber";
            txtTicketNumber.Size = new Size(150, 23);
            txtTicketNumber.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(631, 304);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 7;
            label2.Text = "Número de ticket";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(631, 359);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 9;
            label3.Text = "Número de factura";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(631, 377);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new Size(150, 23);
            txtInvoiceNumber.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(631, 188);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 95);
            textBox1.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(631, 170);
            label4.Name = "label4";
            label4.Size = new Size(150, 15);
            label4.TabIndex = 5;
            label4.Text = "Detalle de metodo de pago";
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(631, 50);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(150, 23);
            cmbCustomer.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(631, 32);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 5;
            label5.Text = "Cliente";
            // 
            // SalesManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 590);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(txtInvoiceNumber);
            Controls.Add(label2);
            Controls.Add(txtTicketNumber);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(cmbCustomer);
            Controls.Add(comboBox1);
            Controls.Add(btnAddProducts);
            Controls.Add(advancedDataGridView2);
            Controls.Add(label1);
            Controls.Add(advancedDataGridView1);
            Name = "SalesManagementForm";
            Text = "SalesManagementForm";
            ((System.ComponentModel.ISupportInitialize)advancedDataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)advancedDataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private Label label1;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView2;
        private Button btnAddProducts;
        private ComboBox comboBox1;
        private Label cmbPaymentMethod;
        private TextBox txtTicketNumber;
        private Label label2;
        private Label label3;
        private TextBox txtInvoiceNumber;
        private TextBox textBox1;
        private Label label4;
        private ComboBox cmbCustomer;
        private Label label5;
    }
}