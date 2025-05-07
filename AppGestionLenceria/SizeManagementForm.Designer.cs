namespace UI
{
    partial class SizeManagementForm
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
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            txtName = new TextBox();
            label1 = new Label();
            dgvSizes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSizes).BeginInit();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.Location = new Point(638, 312);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 16;
            btnClear.Text = "Limpiar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(557, 312);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(476, 312);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 18;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(22, 44);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 26);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 14;
            label1.Text = "Nombre";
            // 
            // dgvSizes
            // 
            dgvSizes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSizes.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSizes.Location = new Point(148, 44);
            dgvSizes.MultiSelect = false;
            dgvSizes.Name = "dgvSizes";
            dgvSizes.ReadOnly = true;
            dgvSizes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSizes.Size = new Size(565, 262);
            dgvSizes.TabIndex = 13;
            dgvSizes.SelectionChanged += dgvSizes_SelectionChanged;
            // 
            // SizeManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(dgvSizes);
            Name = "SizeManagementForm";
            Text = "Gestion de tamaños";
            WindowState = FormWindowState.Maximized;
            Load += SizeManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSizes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private TextBox txtName;
        private Label label1;
        private DataGridView dgvSizes;
    }
}