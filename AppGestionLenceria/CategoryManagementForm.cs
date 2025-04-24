using Domain.Entities;
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

namespace UI
{
    public partial class CategoryManagementForm : Form
    {
        private readonly ICategoryService _categoryService;
        private IEnumerable<Category> _categories = Enumerable.Empty<Category>();
        private int? selectedCategoryId = null;

        protected IServiceProvider ServiceProvider { get; }
        public CategoryManagementForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _categoryService = GetService<ICategoryService>();
            InitializeComponent();
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }

        private async Task LoadData()
        {
            //load category list
            try
            {
                _categories = await _categoryService.GetAllAsync();
                dgvCategories.DataSource = _categories.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error Loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CategoryManagementForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void ClearForm()
        {
            selectedCategoryId = null;
            txtName.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length < 1)
                {
                    MessageBox.Show("The Category needs a name, please insert one", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_categories.Any(s => s.Name.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("The Category already exist, please put another name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isUpdating = selectedCategoryId.HasValue;



                if (isUpdating)
                {
                    int categoryId = selectedCategoryId.Value;
                    var category = await _categoryService.GetByIdAsync(categoryId);
                    category.Name = txtName.Text;
                    await _categoryService.UpdateAsync(category);
                }
                else
                {
                    var category = new Category
                    {
                        Name = txtName.Text,
                    };

                    category = await _categoryService.CreateAsync(category);

                }

                MessageBox.Show("Category saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data
                await LoadData();
                selectedCategoryId = null;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error saving category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!selectedCategoryId.HasValue)
            {
                MessageBox.Show("Please select a category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _categoryService.DeleteAsync(selectedCategoryId.Value);
                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    await LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                selectedCategoryId = (int)dgvCategories.SelectedRows[0].Cells["Id"].Value;

                var category = await _categoryService.GetByIdAsync(selectedCategoryId.Value);

                txtName.Text = category.Name;
            }
        }
    }
}
