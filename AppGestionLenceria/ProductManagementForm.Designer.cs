using Zuby.ADGV;

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
            components = new System.ComponentModel.Container();
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
            numRoundedPrice = new NumericUpDown();
            label10 = new Label();
            label11 = new Label();
            numCalculatedPrice = new NumericUpDown();
            label12 = new Label();
            numProfitability = new NumericUpDown();
            label13 = new Label();
            txtOrderNumber = new TextBox();
            dgvProducts = new AdvancedDataGridView();
            advancedDataGridViewSearchToolBar1 = new AdvancedDataGridViewSearchToolBar();
            errorProviderProduct = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRoundedPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCalculatedPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numProfitability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderProduct).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(21, 50);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 1;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(21, 94);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(200, 23);
            numQuantity.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 32);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 3;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 76);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "Cantidad";
            // 
            // numCost
            // 
            numCost.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numCost.Location = new Point(21, 138);
            numCost.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numCost.Name = "numCost";
            numCost.Size = new Size(200, 23);
            numCost.TabIndex = 3;
            // 
            // numDiscount
            // 
            numDiscount.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numDiscount.Location = new Point(21, 182);
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(200, 23);
            numDiscount.TabIndex = 4;
            numDiscount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 120);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "Costo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 164);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 4;
            label4.Text = "Tasa de descuento";
            // 
            // txtSKU
            // 
            txtSKU.Location = new Point(21, 314);
            txtSKU.Name = "txtSKU";
            txtSKU.Size = new Size(200, 23);
            txtSKU.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 296);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 3;
            label5.Text = "SKU";
            // 
            // cmbSupplier
            // 
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(21, 446);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(200, 23);
            cmbSupplier.TabIndex = 10;
            // 
            // cmbSize
            // 
            cmbSize.FormattingEnabled = true;
            cmbSize.Location = new Point(21, 490);
            cmbSize.Name = "cmbSize";
            cmbSize.Size = new Size(200, 23);
            cmbSize.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 428);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 3;
            label6.Text = "Proveedor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 472);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 3;
            label7.Text = "Tamaño";
            // 
            // clbColors
            // 
            clbColors.FormattingEnabled = true;
            clbColors.Location = new Point(21, 534);
            clbColors.Name = "clbColors";
            clbColors.Size = new Size(200, 94);
            clbColors.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 516);
            label8.Name = "label8";
            label8.Size = new Size(47, 15);
            label8.TabIndex = 8;
            label8.Text = "Colores";
            // 
            // clbCategories
            // 
            clbCategories.FormattingEnabled = true;
            clbCategories.Location = new Point(21, 649);
            clbCategories.Name = "clbCategories";
            clbCategories.Size = new Size(200, 94);
            clbCategories.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 631);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 8;
            label9.Text = "Categorias";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(764, 664);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 14;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(845, 664);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(926, 664);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 16;
            btnClear.Text = "Limpiar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // numRoundedPrice
            // 
            numRoundedPrice.Location = new Point(21, 270);
            numRoundedPrice.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numRoundedPrice.Name = "numRoundedPrice";
            numRoundedPrice.Size = new Size(200, 23);
            numRoundedPrice.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 252);
            label10.Name = "label10";
            label10.Size = new Size(110, 15);
            label10.TabIndex = 10;
            label10.Text = "Precio Redondeado";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(21, 208);
            label11.Name = "label11";
            label11.Size = new Size(96, 15);
            label11.TabIndex = 10;
            label11.Text = "Precio Calculado";
            // 
            // numCalculatedPrice
            // 
            numCalculatedPrice.Enabled = false;
            numCalculatedPrice.Location = new Point(21, 226);
            numCalculatedPrice.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numCalculatedPrice.Name = "numCalculatedPrice";
            numCalculatedPrice.ReadOnly = true;
            numCalculatedPrice.Size = new Size(200, 23);
            numCalculatedPrice.TabIndex = 5;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(21, 340);
            label12.Name = "label12";
            label12.Size = new Size(73, 15);
            label12.TabIndex = 10;
            label12.Text = "Rentabilidad";
            // 
            // numProfitability
            // 
            numProfitability.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numProfitability.Location = new Point(21, 358);
            numProfitability.Name = "numProfitability";
            numProfitability.Size = new Size(200, 23);
            numProfitability.TabIndex = 8;
            numProfitability.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(21, 384);
            label13.Name = "label13";
            label13.Size = new Size(101, 15);
            label13.TabIndex = 13;
            label13.Text = "Numero de orden";
            // 
            // txtOrderNumber
            // 
            txtOrderNumber.Location = new Point(21, 402);
            txtOrderNumber.Name = "txtOrderNumber";
            txtOrderNumber.Size = new Size(200, 23);
            txtOrderNumber.TabIndex = 9;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.FilterAndSortEnabled = true;
            dgvProducts.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            dgvProducts.Location = new Point(242, 76);
            dgvProducts.MaxFilterButtonImageHeight = 23;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RightToLeft = RightToLeft.No;
            dgvProducts.Size = new Size(847, 582);
            dgvProducts.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            dgvProducts.TabIndex = 17;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged_1;
            // 
            // advancedDataGridViewSearchToolBar1
            // 
            advancedDataGridViewSearchToolBar1.AllowMerge = false;
            advancedDataGridViewSearchToolBar1.GripStyle = ToolStripGripStyle.Hidden;
            advancedDataGridViewSearchToolBar1.Location = new Point(0, 0);
            advancedDataGridViewSearchToolBar1.MaximumSize = new Size(0, 27);
            advancedDataGridViewSearchToolBar1.MinimumSize = new Size(0, 27);
            advancedDataGridViewSearchToolBar1.Name = "advancedDataGridViewSearchToolBar1";
            advancedDataGridViewSearchToolBar1.RenderMode = ToolStripRenderMode.Professional;
            advancedDataGridViewSearchToolBar1.Size = new Size(1121, 27);
            advancedDataGridViewSearchToolBar1.TabIndex = 18;
            advancedDataGridViewSearchToolBar1.Text = "Busqueda";
            advancedDataGridViewSearchToolBar1.Search += advancedDataGridViewSearchToolBar1_Search;
            // 
            // errorProviderProduct
            // 
            errorProviderProduct.ContainerControl = this;
            // 
            // ProductManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1121, 774);
            Controls.Add(advancedDataGridViewSearchToolBar1);
            Controls.Add(dgvProducts);
            Controls.Add(label13);
            Controls.Add(txtOrderNumber);
            Controls.Add(numCalculatedPrice);
            Controls.Add(numProfitability);
            Controls.Add(numRoundedPrice);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
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
            Name = "ProductManagementForm";
            Text = "Gestion de productos";
            Load += ProductManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRoundedPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCalculatedPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numProfitability).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private NumericUpDown numRoundedPrice;
        private Label label10;
        private Label label11;
        private NumericUpDown numCalculatedPrice;
        private Label label12;
        private NumericUpDown numProfitability;
        private Label label13;
        private TextBox txtOrderNumber;
        private AdvancedDataGridView dgvProducts;
        private AdvancedDataGridViewSearchToolBar advancedDataGridViewSearchToolBar1;
        private ErrorProvider errorProviderProduct;
    }
}
