namespace UI
{
    partial class ColorManagementForm
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
            dgvColors = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvColors).BeginInit();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.Location = new Point(543, 280);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 22;
            btnClear.Text = "Limpiar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(462, 280);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(381, 280);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 24;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(13, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 17);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 20;
            label1.Text = "Nombre";
            // 
            // dgvColors
            // 
            dgvColors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColors.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvColors.Location = new Point(183, 12);
            dgvColors.MultiSelect = false;
            dgvColors.Name = "dgvColors";
            dgvColors.ReadOnly = true;
            dgvColors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvColors.Size = new Size(433, 262);
            dgvColors.TabIndex = 19;
            dgvColors.SelectionChanged += dgvColors_SelectionChanged;
            // 
            // ColorManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(dgvColors);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ColorManagementForm";
            Text = "Gestion de colores";
            WindowState = FormWindowState.Maximized;
            Load += ColorManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvColors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private TextBox txtName;
        private Label label1;
        private DataGridView dgvColors;
    }
}