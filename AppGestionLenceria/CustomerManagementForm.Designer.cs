namespace UI
{
    partial class CustomerManagementForm
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
            dgvCustomers = new Zuby.ADGV.AdvancedDataGridView();
            label1 = new Label();
            txtName = new TextBox();
            txtPhone = new TextBox();
            label2 = new Label();
            txtEMail = new TextBox();
            label3 = new Label();
            txtSocialMedia = new TextBox();
            label4 = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.FilterAndSortEnabled = true;
            dgvCustomers.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            dgvCustomers.Location = new Point(237, 28);
            dgvCustomers.MaxFilterButtonImageHeight = 23;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RightToLeft = RightToLeft.No;
            dgvCustomers.Size = new Size(537, 348);
            dgvCustomers.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            dgvCustomers.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 28);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // txtName
            // 
            txtName.Location = new Point(19, 46);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(19, 93);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 75);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Telefono";
            // 
            // txtEMail
            // 
            txtEMail.Location = new Point(19, 143);
            txtEMail.Name = "txtEMail";
            txtEMail.Size = new Size(100, 23);
            txtEMail.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 125);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 5;
            label3.Text = "E-Mail";
            // 
            // txtSocialMedia
            // 
            txtSocialMedia.Location = new Point(19, 193);
            txtSocialMedia.Multiline = true;
            txtSocialMedia.Name = "txtSocialMedia";
            txtSocialMedia.Size = new Size(100, 87);
            txtSocialMedia.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 175);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 7;
            label4.Text = "Redes sociales";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(698, 382);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 19;
            btnClear.Text = "Limpiar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(617, 382);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += this.btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(536, 382);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 21;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // CustomerManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(txtSocialMedia);
            Controls.Add(label4);
            Controls.Add(txtEMail);
            Controls.Add(label3);
            Controls.Add(txtPhone);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(dgvCustomers);
            Name = "CustomerManagementForm";
            Text = "CostumerManagementForm";
            Load += CustomerManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvCustomers;
        private Label label1;
        private TextBox txtName;
        private TextBox txtPhone;
        private Label label2;
        private TextBox txtEMail;
        private Label label3;
        private TextBox txtSocialMedia;
        private Label label4;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
    }
}