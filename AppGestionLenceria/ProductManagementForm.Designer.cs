namespace AppGestionLenceria
{
    partial class ProductManagementForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProducts = new DataGridView();
            txtName = new TextBox();
            numQuantity = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            numCost = new NumericUpDown();
            numDiscount = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            txtSKU = new TextBox();
            label5 = new Label();
            cmbSupplier = new ComboBox();
            cmbSize = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            clbColors = new CheckedListBox();
            label8 = new Label();
            clbCategories = new CheckedListBox();
            label9 = new Label();
            btnSave = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(241, 36);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(760, 434);
            dgvProducts.TabIndex = 0;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(27, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(120, 23);
            txtName.TabIndex = 1;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(27, 83);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 18);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 3;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 64);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "Cantidad";
            // 
            // numCost
            // 
            numCost.Location = new Point(27, 129);
            numCost.Name = "numCost";
            numCost.Size = new Size(120, 23);
            numCost.TabIndex = 5;
            // 
            // numDiscount
            // 
            numDiscount.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numDiscount.Location = new Point(27, 175);
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(120, 23);
            numDiscount.TabIndex = 5;
            numDiscount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 110);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "Costo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 156);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 4;
            label4.Text = "Descuento";
            // 
            // txtSKU
            // 
            txtSKU.Location = new Point(27, 221);
            txtSKU.Name = "txtSKU";
            txtSKU.Size = new Size(121, 23);
            txtSKU.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 202);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 3;
            label5.Text = "SKU";
            // 
            // cmbSupplier
            // 
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(27, 267);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(121, 23);
            cmbSupplier.TabIndex = 6;
            // 
            // cmbSize
            // 
            cmbSize.FormattingEnabled = true;
            cmbSize.Location = new Point(27, 313);
            cmbSize.Name = "cmbSize";
            cmbSize.Size = new Size(121, 23);
            cmbSize.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 248);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 3;
            label6.Text = "Proveedor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 294);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 3;
            label7.Text = "Tamaño";
            // 
            // clbColors
            // 
            clbColors.FormattingEnabled = true;
            clbColors.Location = new Point(27, 359);
            clbColors.Name = "clbColors";
            clbColors.Size = new Size(120, 94);
            clbColors.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(27, 340);
            label8.Name = "label8";
            label8.Size = new Size(47, 15);
            label8.TabIndex = 8;
            label8.Text = "Colores";
            // 
            // clbCategories
            // 
            clbCategories.FormattingEnabled = true;
            clbCategories.Location = new Point(27, 476);
            clbCategories.Name = "clbCategories";
            clbCategories.Size = new Size(120, 94);
            clbCategories.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(27, 457);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 8;
            label9.Text = "Categorias";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(764, 476);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(845, 476);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(926, 476);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 9;
            btnClear.Text = "Limpiar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // ProductManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 598);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(clbCategories);
            Controls.Add(clbColors);
            Controls.Add(cmbSize);
            Controls.Add(cmbSupplier);
            Controls.Add(numDiscount);
            Controls.Add(numCost);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(numQuantity);
            Controls.Add(txtSKU);
            Controls.Add(txtName);
            Controls.Add(dgvProducts);
            Name = "ProductManagementForm";
            Text = "Form1";
            Load += ProductManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProducts;
        private TextBox txtName;
        private NumericUpDown numQuantity;
        private Label label1;
        private Label label2;
        private NumericUpDown numCost;
        private NumericUpDown numDiscount;
        private Label label3;
        private Label label4;
        private TextBox txtSKU;
        private Label label5;
        private ComboBox cmbSupplier;
        private ComboBox cmbSize;
        private Label label6;
        private Label label7;
        private CheckedListBox clbColors;
        private Label label8;
        private CheckedListBox clbCategories;
        private Label label9;
        private Button btnSave;
        private Button btnDelete;
        private Button btnClear;
    }
}
