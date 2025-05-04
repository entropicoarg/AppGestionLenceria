using Domain.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UI
{
    public partial class SalesManagementForm : Form
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private int? selectedProductId = null;
        private int? selectedProductSaleId = null;
        private IEnumerable<Product> _products = Enumerable.Empty<Product>();
        private IEnumerable<Sale> _sales = Enumerable.Empty<Sale>();
        private DataTable _productsDataTable;
        private BindingSource _productsBindingSource = new BindingSource();
        private BindingSource _selectedProductsBindingSource = new BindingSource();
        private BindingSource _salesBindingSource = new BindingSource();
        private List<Product> _selectedProducts = new List<Product>();

        protected IServiceProvider ServiceProvider { get; }
        public SalesManagementForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _productService = GetService<IProductService>();
            _saleService = GetService<ISaleService>();

            InitializeComponent();
        }
        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }

        private async Task<DataTable> ConvertProductsToDataTableWithRelationsAsync(IEnumerable<Product> products)
        {

            var productsDataTable = new DataTable();
            // Add columns
            productsDataTable.Columns.Add("Id", typeof(int));
            productsDataTable.Columns.Add("Nombre", typeof(string));
            productsDataTable.Columns.Add("Cantidad", typeof(int));
            productsDataTable.Columns.Add("Costo", typeof(decimal));
            productsDataTable.Columns.Add("TasaDescuento", typeof(decimal));
            productsDataTable.Columns.Add("PrecioCalculado", typeof(decimal));
            productsDataTable.Columns.Add("PrecioRedondeado", typeof(decimal));
            productsDataTable.Columns.Add("SKU", typeof(string));
            productsDataTable.Columns.Add("Rentabilidad", typeof(decimal));
            productsDataTable.Columns.Add("Orden", typeof(string));
            productsDataTable.Columns.Add("Proveedor", typeof(string));  // Supplier name
            productsDataTable.Columns.Add("Talla", typeof(string));      // Size name
            productsDataTable.Columns.Add("Colores", typeof(string));    // Color names
            productsDataTable.Columns.Add("Categorias", typeof(string)); // Category names

            // Add rows for each product
            foreach (var product in _products)
            {
                var row = productsDataTable.NewRow();
                row["Id"] = product.Id;
                row["Nombre"] = product.Name;
                row["Cantidad"] = product.Quantity;
                row["Costo"] = product.Cost;
                row["TasaDescuento"] = product.DiscountRate;
                row["PrecioCalculado"] = product.CalculatedPrice;
                row["PrecioRedondeado"] = product.RoundedPrice;
                row["SKU"] = product.SKU ?? string.Empty;
                row["Rentabilidad"] = product.Profitability;
                row["Orden"] = product.OrderNumber ?? string.Empty;

                // Add supplier and size information
                row["Proveedor"] = product.Supplier?.Name ?? string.Empty;
                row["Talla"] = product.Size?.Name ?? string.Empty;

                // Add comma-separated lists of color and category names
                row["Colores"] = string.Join(", ", product.ProductColors.Select(pc => pc.Color.Name));
                row["Categorias"] = string.Join(", ", product.ProductCategories.Select(pc => pc.Category.Name));

                productsDataTable.Rows.Add(row);
            }


            return productsDataTable;
        }

        public void PopulateQuantityComboBox(ComboBox comboBox, Product product)
        {
            // Clear existing items
            comboBox.Items.Clear();
            comboBox.Text = "";
            if (product.Quantity < 1) return;

            // Add items from 1 to the product quantity
            for (int i = 1; i <= product.Quantity; i++)
            {
                comboBox.Items.Add(i.ToString());
            }

            // Select the first item if available
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        private void LoadProductQuantity(Product selectedProduct)
        {
            if (selectedProduct != null)
            {
                PopulateQuantityComboBox(cmbQuantity, selectedProduct);
            }
        }


        private async void LoadData()
        {
            try
            {
                _products = await _productService.GetAllWithRelationsAsync();
                _productsDataTable = await ConvertProductsToDataTableWithRelationsAsync(_products);
                _sales = await _saleService.GetAllAsync();
                _productsBindingSource.DataSource = _productsDataTable;
                dgvProducts.DataSource = _productsBindingSource;
                _selectedProductsBindingSource.DataSource = _selectedProducts;
                dgvSelectedProducts.DataSource = _selectedProductsBindingSource;
                _salesBindingSource.DataSource = _sales;
                dgvSales.DataSource = _salesBindingSource;
                selectedProductId = null;
                selectedProductSaleId = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalesManagementForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    if (dgvProducts.SelectedRows[0].Cells["Id"].Value is DBNull) throw new NullReferenceException();
                    // Get selected product ID
                    selectedProductId = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;

                    // Load product with all relations
                    var product = await _productService.GetWithAllRelationsAsync(selectedProductId.Value);

                    LoadProductQuantity(product);



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void btnAddProducts_Click(object sender, EventArgs e)
        {
            try
            {
                if (!selectedProductId.HasValue)
                {
                    MessageBox.Show("Please select a product first.", "No Product Selected",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the selected product with current inventory
                Product selectedProduct = await _productService.GetByIdAsync(selectedProductId.Value);
                if (selectedProduct == null)
                {
                    MessageBox.Show("Selected product not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the selected quantity from combobox
                if (cmbQuantity.SelectedItem == null)
                {
                    MessageBox.Show("Please select a quantity.", "No Quantity Selected",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int selectedQuantity = int.Parse(cmbQuantity.SelectedItem.ToString());

                // Check if we have enough stock
                if (selectedQuantity > selectedProduct.Quantity)
                {
                    MessageBox.Show($"Not enough stock. Only {selectedProduct.Quantity} items available.",
                        "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if this product is already in the selected products list
                Product existingProduct = _selectedProducts.FirstOrDefault(p => p.Id == selectedProduct.Id);
                if (existingProduct != null)
                {
                    // Ask user if they want to update the quantity instead
                    DialogResult result = MessageBox.Show(
                        "This product is already in your cart. Do you want to update the quantity?",
                        "Product Already Selected",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Remove existing entry to update it

                        _selectedProducts.FirstOrDefault(p => p.Id == existingProduct.Id).Quantity += selectedQuantity;

                    }
                    else
                    {
                        return; // User canceled
                    }
                }
                else
                {
                    Product productToAdd = new Product
                    {
                        Id = selectedProduct.Id,
                        Name = selectedProduct.Name,
                        Cost = selectedProduct.Cost,
                        DiscountRate = selectedProduct.DiscountRate,
                        Profitability = selectedProduct.Profitability,
                        RoundedPrice = selectedProduct.RoundedPrice,
                        SKU = selectedProduct.SKU,
                        OrderNumber = selectedProduct.OrderNumber,
                        SupplierId = selectedProduct.SupplierId,
                        Supplier = selectedProduct.Supplier,
                        SizeId = selectedProduct.SizeId,
                        Size = selectedProduct.Size,
                        Quantity = selectedQuantity // Set the selected quantity
                    };

                    // Add to selected products list
                    _selectedProducts.Add(productToAdd);
                }

                // Update the original product quantity in the products list
                Product originalProduct = _products.FirstOrDefault(p => p.Id == selectedProduct.Id);
                if (originalProduct != null)
                {
                    originalProduct.Quantity -= selectedQuantity;
                }
                LoadData();

                // Refresh data bindings
                RefreshProductsDisplay();

                // Show confirmation
                MessageBox.Show($"{selectedQuantity} {selectedProduct.Name} added to cart.",
                    "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to refresh the data displayed in both DataGridViews
        private void RefreshProductsDisplay()
        {
            //// Refresh the selected products grid
            //if (dgvSelectedProducts.DataSource is List<Product>)
            //{
            //    // If bound directly to the list, refresh with a new binding
            //    dgvSelectedProducts.DataSource = null;
            //    dgvSelectedProducts.DataSource = new List<Product>(_selectedProducts);
            //}
            //else
            //{
            //    // Create a binding source for selected products if needed
            //    BindingSource selectedProductsBinding = new BindingSource
            //    {
            //        DataSource = new List<Product>(_selectedProducts)
            //    };
            //    dgvSelectedProducts.DataSource = selectedProductsBinding;
            //}
            _selectedProductsBindingSource.ResetBindings(false);
            _salesBindingSource.ResetBindings(false);
            // Refresh the main products grid
            _productsBindingSource.ResetBindings(false);

            // If there's a selected product, update its quantity combobox
            if (selectedProductId.HasValue)
            {
                Product currentProduct = _products.FirstOrDefault(p => p.Id == selectedProductId.Value);
                if (currentProduct != null)
                {
                    LoadProductQuantity(currentProduct);
                }
            }
        }

        private async void btnRemoveProducts_Click(object sender, EventArgs e)
        {
            try
            {
                if (!selectedProductSaleId.HasValue)
                {
                    MessageBox.Show("Please select a product first.", "No Product Selected",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                Product selectedProduct = _selectedProducts.FirstOrDefault(x => x.Id == selectedProductSaleId);


                _selectedProducts.Remove(selectedProduct);

                // Update the original product quantity in the products list
                Product originalProduct = _products.FirstOrDefault(p => p.Id == selectedProductSaleId);
                if (originalProduct != null)
                {
                    originalProduct.Quantity += selectedProduct.Quantity;
                }
                LoadData();

                // Refresh data bindings
                RefreshProductsDisplay();

                // Show confirmation
                MessageBox.Show($"{selectedProduct.Quantity} {selectedProduct.Name} removed from cart.",
                    "Product Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing product: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSelectedProducts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvSelectedProducts.SelectedRows.Count > 0)
                {
                    if (dgvSelectedProducts.SelectedRows[0].Cells["Id"].Value is DBNull) throw new NullReferenceException();
                    // Get selected product ID
                    selectedProductSaleId = (int)dgvSelectedProducts.SelectedRows[0].Cells["Id"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CleanSelectedProducts()
        {
            _selectedProducts.Clear();
        }

        private void btnNewSale_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Desea crear una nueva venta?", "Nueva venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            if (result == DialogResult.Yes)
            {
                NewSaleForm saleForm = new NewSaleForm(_selectedProducts, ServiceProvider);
                saleForm.ShowDialog();
            }
            CleanSelectedProducts();
            LoadData();
            RefreshProductsDisplay();
            
        }
    }
}
