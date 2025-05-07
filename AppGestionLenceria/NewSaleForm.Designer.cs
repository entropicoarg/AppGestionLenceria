namespace UI
{
    partial class NewSaleForm
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
            txtPaymentMethodDetail = new TextBox();
            label3 = new Label();
            txtInvoiceNumber = new TextBox();
            label2 = new Label();
            txtTicketNumber = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cmbPaymentMethod = new Label();
            cmbCustomer = new ComboBox();
            cmbPaymentMethods = new ComboBox();
            btnSave = new Button();
            btnExit = new Button();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            groupBoxSale = new GroupBox();
            groupBoxSale.SuspendLayout();
            SuspendLayout();
            // 
            // txtPaymentMethodDetail
            // 
            txtPaymentMethodDetail.Location = new Point(10, 134);
            txtPaymentMethodDetail.Multiline = true;
            txtPaymentMethodDetail.Name = "txtPaymentMethodDetail";
            txtPaymentMethodDetail.Size = new Size(150, 95);
            txtPaymentMethodDetail.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 276);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 19;
            label3.Text = "Número de factura";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(10, 294);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new Size(150, 23);
            txtInvoiceNumber.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 232);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 17;
            label2.Text = "Número de ticket";
            // 
            // txtTicketNumber
            // 
            txtTicketNumber.Location = new Point(10, 250);
            txtTicketNumber.Name = "txtTicketNumber";
            txtTicketNumber.Size = new Size(150, 23);
            txtTicketNumber.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 116);
            label4.Name = "label4";
            label4.Size = new Size(150, 15);
            label4.TabIndex = 13;
            label4.Text = "Detalle de metodo de pago";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 28);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 14;
            label5.Text = "Cliente";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.AutoSize = true;
            cmbPaymentMethod.Location = new Point(10, 72);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(95, 15);
            cmbPaymentMethod.TabIndex = 15;
            cmbPaymentMethod.Text = "Metodo de pago";
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(10, 46);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(150, 23);
            cmbCustomer.TabIndex = 11;
            // 
            // cmbPaymentMethods
            // 
            cmbPaymentMethods.FormattingEnabled = true;
            cmbPaymentMethods.Location = new Point(10, 90);
            cmbPaymentMethods.Name = "cmbPaymentMethods";
            cmbPaymentMethods.Size = new Size(150, 23);
            cmbPaymentMethods.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(14, 408);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 21;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(95, 408);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 22;
            btnExit.Text = "Salir";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(10, 338);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(149, 23);
            dateTimePicker1.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 320);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 24;
            label1.Text = "Fecha de venta";
            // 
            // groupBoxSale
            // 
            groupBoxSale.Controls.Add(txtPaymentMethodDetail);
            groupBoxSale.Controls.Add(label1);
            groupBoxSale.Controls.Add(cmbPaymentMethods);
            groupBoxSale.Controls.Add(dateTimePicker1);
            groupBoxSale.Controls.Add(cmbCustomer);
            groupBoxSale.Controls.Add(btnExit);
            groupBoxSale.Controls.Add(cmbPaymentMethod);
            groupBoxSale.Controls.Add(btnSave);
            groupBoxSale.Controls.Add(label5);
            groupBoxSale.Controls.Add(label4);
            groupBoxSale.Controls.Add(label3);
            groupBoxSale.Controls.Add(txtTicketNumber);
            groupBoxSale.Controls.Add(txtInvoiceNumber);
            groupBoxSale.Controls.Add(label2);
            groupBoxSale.Location = new Point(12, 12);
            groupBoxSale.Name = "groupBoxSale";
            groupBoxSale.Size = new Size(184, 437);
            groupBoxSale.TabIndex = 25;
            groupBoxSale.TabStop = false;
            groupBoxSale.Text = "Nueva venta";
            // 
            // NewSaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(215, 461);
            Controls.Add(groupBoxSale);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "NewSaleForm";
            Text = "NewSaleForm";
            WindowState = FormWindowState.Maximized;
            Load += NewSaleForm_Load;
            groupBoxSale.ResumeLayout(false);
            groupBoxSale.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtPaymentMethodDetail;
        private Label label3;
        private TextBox txtInvoiceNumber;
        private Label label2;
        private TextBox txtTicketNumber;
        private Label label4;
        private Label label5;
        private Label cmbPaymentMethod;
        private ComboBox cmbCustomer;
        private ComboBox cmbPaymentMethods;
        private Button btnSave;
        private Button btnExit;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private GroupBox groupBoxSale;
    }
}