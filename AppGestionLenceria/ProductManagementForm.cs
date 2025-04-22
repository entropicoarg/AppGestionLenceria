
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

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
            var products = await _productService.GetAllAsync();
            dgvProducts.DataSource = products.ToList();

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
                var product = new Product
                {
                    Name = txtName.Text,
                    Quantity = (int)numQuantity.Value,
                    Cost = numCost.Value,
                    DiscountAmount = numDiscount.Value,
                    RoundedPrice = Math.Ceiling(numCost.Value + numDiscount.Value), // Example price rounding
                    SKU = txtSKU.Text,
                    SupplierId = (int)cmbSupplier.SelectedValue,
                    SizeId = (int)cmbSize.SelectedValue
                };

                // Update or create
                if (selectedProductId.HasValue)
                {
                    product.Id = selectedProductId.Value;
                    await _productService.UpdateAsync(product);
                }
                else
                {
                    product = await _productService.CreateAsync(product);
                    selectedProductId = product.Id;
                }

                // Handle many-to-many relationships for colors
                // First clear existing associations
                var currentColors = await _productService.GetProductColorsAsync(product.Id);
                foreach (var color in currentColors)
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
                var currentCategories = await _productService.GetProductCategoriesAsync(product.Id);
                foreach (var category in currentCategories)
                {
                    await _categoryService.RemoveProductCategoryAsync(product.Id, category.Id);
                }

                // Add new associations
                for (int i = 0; i < clbCategories.CheckedItems.Count; i++)
                {
                    var category = (Category)clbCategories.CheckedItems[i];
                    await _categoryService.AddProductCategoryAsync(product.Id, category.Id);
                }

                MessageBox.Show("Product saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data
                await LoadData();
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
                numDiscount.Value = product.DiscountAmount;
                txtSKU.Text = product.SKU;

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

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
