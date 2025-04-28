
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using Services.Utils;

namespace AppGestionLenceria
{
    public partial class ProductManagementForm : Form
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        private readonly ICategoryService _categoryService;
        protected IServiceProvider ServiceProvider { get; }


        private int? selectedProductId = null;
        private IEnumerable<Product> _products = Enumerable.Empty<Product>();

        public ProductManagementForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _productService = GetService<IProductService>();
            _supplierService = GetService<ISupplierService>();
            _sizeService = GetService<ISizeService>();
            _colorService = GetService<IColorService>();
            _categoryService = GetService<ICategoryService>();

            InitializeComponent();
        }

        private async Task LoadData()
        {
            // Load products for the grid
            _products = await _productService.GetAllAsync();
            dgvProducts.DataSource = _products.ToList();

            // Load suppliers for dropdown
            var suppliers = await _supplierService.GetAllAsync();
            cmbSupplier.DataSource = suppliers.ToList();
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "Id";

            // Load sizes for dropdown
            var sizes = await _sizeService.GetAllAsync();
            cmbSize.DataSource = sizes.ToList();
            cmbSize.DisplayMember = "Name";
            cmbSize.ValueMember = "Id";

            // Load colors for checklist
            var colors = await _colorService.GetAllAsync();
            clbColors.Items.Clear();
            foreach (var color in colors)
            {
                clbColors.Items.Add(color, false);
            }
            clbColors.DisplayMember = "Name";
            clbColors.ValueMember = "Id";

            // Load categories for checklist
            var categories = await _categoryService.GetAllAsync();
            clbCategories.Items.Clear();
            foreach (var category in categories)
            {
                clbCategories.Items.Add(category, false);
            }
            clbCategories.DisplayMember = "Name";
            clbCategories.ValueMember = "Id";
        }

        private void ClearForm()
        {
            selectedProductId = null;
            txtName.Text = string.Empty;
            numQuantity.Value = 0;
            numCost.Value = 0;
            numDiscount.Value = 0;
            txtSKU.Text = string.Empty;

            // Clear selections
            if (cmbSupplier.Items.Count > 0) cmbSupplier.SelectedIndex = 0;
            if (cmbSize.Items.Count > 0) cmbSize.SelectedIndex = 0;

            // Uncheck all colors and categories
            for (int i = 0; i < clbColors.Items.Count; i++)
            {
                clbColors.SetItemChecked(i, false);
            }

            for (int i = 0; i < clbCategories.Items.Count; i++)
            {
                clbCategories.SetItemChecked(i, false);
            }
        }

        private async void ProductManagementForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!selectedProductId.HasValue)
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _productService.DeleteAsync(selectedProductId.Value);
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    await LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Create product object from form data
                //var product = new Product
                //{
                //    Name = txtName.Text,
                //    Quantity = (int)numQuantity.Value,
                //    Cost = numCost.Value,
                //    DiscountRate = numDiscount.Value,
                //    RoundedPrice = numRoundedPrice.Value, // Example price rounding
                //    SKU = txtSKU.Text,
                //    SupplierId = (int)cmbSupplier.SelectedValue,
                //    SizeId = (int)cmbSize.SelectedValue
                //};

                bool isUpdating = selectedProductId.HasValue;

                if (isUpdating)
                {
                    int productId = selectedProductId.Value;
                    var product = await _productService.GetWithAllRelationsAsync(productId);
                    product.Name = txtName.Text;
                    product.Quantity = (int)numQuantity.Value;
                    product.Cost = numCost.Value;
                    product.DiscountRate = numDiscount.Value;
                    product.RoundedPrice = numRoundedPrice.Value;
                    product.SKU = txtSKU.Text.ToUpper();
                    product.SupplierId = (int)cmbSupplier.SelectedValue;
                    product.SizeId = (int)cmbSize.SelectedValue;
                    product.OrderNumber = txtOrderNumber.Text;
                    product.Profitability = numProfitability.Value;
                    // Handle many-to-many relationships for colors
                    // First clear existing associations
                    foreach (var color in (IEnumerable<Domain.Entities.Color>?)await _productService.GetProductColorsAsync(product.Id))
                    {
                        await _colorService.RemoveProductColorAsync(product.Id, color.Id);
                    }

                    // Add new associations
                    for (int i = 0; i < clbColors.CheckedItems.Count; i++)
                    {
                        var color = (Domain.Entities.Color)clbColors.CheckedItems[i];
                        await _colorService.AddProductColorAsync(product.Id, color.Id);
                    }

                    // Handle many-to-many relationships for categories
                    // First clear existing associations

                    foreach (var category in (IEnumerable<Category>?)await _productService.GetProductCategoriesAsync(product.Id))
                    {
                        await _categoryService.RemoveProductCategoryAsync(product.Id, category.Id);
                    }

                    // Add new associations
                    for (int i = 0; i < clbCategories.CheckedItems.Count; i++)
                    {
                        var category = (Category)clbCategories.CheckedItems[i];
                        await _categoryService.AddProductCategoryAsync(product.Id, category.Id);
                    }
                }
                else
                {
                    //Create product object from form data
                    var product = new Product
                    {
                        Name = txtName.Text,
                        Quantity = (int)numQuantity.Value,
                        Cost = numCost.Value,
                        DiscountRate = numDiscount.Value,
                        RoundedPrice = numRoundedPrice.Value, // Example price rounding
                        SKU = txtSKU.Text,
                        SupplierId = (int)cmbSupplier.SelectedValue,
                        SizeId = (int)cmbSize.SelectedValue,
                        OrderNumber = txtOrderNumber.Text,
                        Profitability = numProfitability.Value
                    };

                    product = await _productService.CreateAsync(product);

                    for (int i = 0; i < clbColors.CheckedItems.Count; i++)
                    {
                        var color = (Domain.Entities.Color)clbColors.CheckedItems[i];
                        await _colorService.AddProductColorAsync(product.Id, color.Id);
                    }

                    for (int i = 0; i < clbCategories.CheckedItems.Count; i++)
                    {
                        var category = (Category)clbCategories.CheckedItems[i];
                        await _categoryService.AddProductCategoryAsync(product.Id, category.Id);
                    }

                    MessageBox.Show("Product saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadData();
                }

                // Update or create
                //if (selectedProductId.HasValue)
                //{
                //    product.Id = selectedProductId.Value;
                //    await _productService.UpdateAsync(product);
                //}
                //else
                //{
                //product = await _productService.CreateAsync(product);
                //    //TODO need to retrieve the ID from the db since it's generated there. 
                //    selectedProductId = product.Id;
                //}

                // Handle many-to-many relationships for colors
                // First clear existing associations
                //var currentColors = await _productService.GetProductColorsAsync(product.Id);
                //foreach (var color in currentColors)
                //{
                //    await _colorService.RemoveProductColorAsync(product.Id, color.Id);
                //}

                //// Add new associations
                //for (int i = 0; i < clbColors.CheckedItems.Count; i++)
                //{
                //    var color = (Domain.Entities.Color)clbColors.CheckedItems[i];
                //    await _colorService.AddProductColorAsync(product.Id, color.Id);
                //}

                //// Handle many-to-many relationships for categories
                //// First clear existing associations
                //var currentCategories = await _productService.GetProductCategoriesAsync(product.Id);
                //foreach (var category in currentCategories)
                //{
                //    await _categoryService.RemoveProductCategoryAsync(product.Id, category.Id);
                //}

                //// Add new associations
                //for (int i = 0; i < clbCategories.CheckedItems.Count; i++)
                //{
                //    var category = (Category)clbCategories.CheckedItems[i];
                //    await _categoryService.AddProductCategoryAsync(product.Id, category.Id);
                //}

                //MessageBox.Show("Product saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //// Reload data
                //await LoadData();
                //selectedProductId = _products.FirstOrDefault(s => s.Name == product.Name).Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Get selected product ID
                selectedProductId = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;

                // Load product with all relations
                var product = await _productService.GetWithAllRelationsAsync(selectedProductId.Value);

                // Fill form fields
                txtName.Text = product.Name;
                numQuantity.Value = product.Quantity;
                numCost.Value = product.Cost;
                numDiscount.Value = product.DiscountRate;
                txtSKU.Text = product.SKU;
                txtOrderNumber.Text = product.OrderNumber;
                numCalculatedPrice.Value = product.CalculatedPrice;
                numProfitability.Value = product.Profitability;
                numRoundedPrice.Value = product.RoundedPrice;

                // Select supplier and size
                cmbSupplier.SelectedValue = product.SupplierId;
                cmbSize.SelectedValue = product.SizeId;

                // Check colors
                var productColors = await _productService.GetProductColorsAsync(selectedProductId.Value);
                for (int i = 0; i < clbColors.Items.Count; i++)
                {
                    var color = (Domain.Entities.Color)clbColors.Items[i];
                    bool isSelected = productColors.Any(c => c.Id == color.Id);
                    clbColors.SetItemChecked(i, isSelected);
                }

                // Check categories
                var productCategories = await _productService.GetProductCategoriesAsync(selectedProductId.Value);
                for (int i = 0; i < clbCategories.Items.Count; i++)
                {
                    var category = (Category)clbCategories.Items[i];
                    bool isSelected = productCategories.Any(c => c.Id == category.Id);
                    clbCategories.SetItemChecked(i, isSelected);
                }
            }
        }

        private void numCost_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage;
            if (!InputsValidator.CostValidator(numCost.Value, out errorMessage))
            {
                e.Cancel = true;
                errorProviderProduct.SetError(numCost, errorMessage);
            }


        }

        private void numCost_Validated(object sender, EventArgs e)
        {
            SetErrorProvider(numCost);
        }

        private void txtSKU_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage;
            if (!InputsValidator.SKUValidator(txtSKU.Text.ToUpper(), out errorMessage))
            {
                e.Cancel = true;
                errorProviderProduct.SetError(txtSKU, errorMessage);
            }
        }

        private void numRoundedPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage;
            if (!InputsValidator.CostValidator(numRoundedPrice.Value, out errorMessage))
            {
                e.Cancel = true;
                errorProviderProduct.SetError(numRoundedPrice, errorMessage);
            }
        }

        private void txtSKU_Validated(object sender, EventArgs e)
        {
            errorProviderProduct.SetError(txtSKU, "");
        }

        private void numRoundedPrice_Validated(object sender, EventArgs e)
        {
            errorProviderProduct.SetError(numRoundedPrice, "");
        }

        private void numDiscount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage;
            if (!InputsValidator.RatesValidator(numDiscount.Value, out errorMessage))
            {
                e.Cancel = true;
                errorProviderProduct.SetError(numDiscount, errorMessage);
            }
        }

        private void numDiscount_Validated(object sender, EventArgs e)
        {
            SetErrorProvider(numDiscount);
        }

        private void numProfitability_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage;
            if (!InputsValidator.RatesValidator(numProfitability.Value, out errorMessage))
            {
                e.Cancel = true;
                errorProviderProduct.SetError(numProfitability, errorMessage);
            }
        }

        private void numProfitability_Validated(object sender, EventArgs e)
        {
            SetErrorProvider(numProfitability);
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }

        private void SetErrorProvider(NumericUpDown num)
        {
            numCalculatedPrice.Value = (numCost.Value * numProfitability.Value) * numDiscount.Value;
            numRoundedPrice.Value = (numCost.Value * numProfitability.Value) * numDiscount.Value;
            errorProviderProduct.SetError(num, "");
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage;
            if (!InputsValidator.NamesValidator(txtName.Text, out errorMessage))
            {
                e.Cancel = true;
                errorProviderProduct.SetError(txtName, errorMessage);
            }
        }

        private void txtOrderNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage;
            if (!InputsValidator.OrderValidator(txtOrderNumber.Text, out errorMessage))
            {
                e.Cancel = true;
                errorProviderProduct.SetError(txtOrderNumber, errorMessage);
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            errorProviderProduct.SetError(txtName, "");
        }

        private void txtOrderNumber_Validated(object sender, EventArgs e)
        {
            errorProviderProduct.SetError(txtOrderNumber, "");
        }
    }
}
