using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using Services.Utils;
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
        private ErrorProvider errorProviderCategory;


        protected IServiceProvider ServiceProvider { get; }
        public CategoryManagementForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _categoryService = GetService<ICategoryService>();
            InitializeComponent();
            SetupErrorProvider();
            ConnectValidationEvents();
        }
        private void SetupErrorProvider()
        {
            errorProviderCategory = new ErrorProvider();
            errorProviderCategory.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage;
            if (!InputsValidator.NamesValidator(txtName.Text, out errorMessage))
            {
                e.Cancel = true;
                errorProviderCategory.SetError(txtName, errorMessage);
            }
        }
        private void txtName_Validated(object sender, EventArgs e)
        {
            errorProviderCategory.SetError(txtName, "");
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

                MessageBox.Show($"Error cargando proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!ValidateChildren())
            {
                MessageBox.Show("Por favor, solucione los errores de validacion antes de guardar",
                         "Error de validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (txtName.Text.Length < 1)
                {
                    MessageBox.Show("La categoria necesita un nombre, por favor ingrese uno", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_categories.Any(s => s.Name.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("La categoria ya existe, por favor ingrese otro nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("Categoria guardada exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data
                await LoadData();
                selectedCategoryId = null;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error guardando categoria: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!selectedCategoryId.HasValue)
            {
                MessageBox.Show("Por favor, seleccione una categoria a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Estas seguro de querer eliminar esta categoria?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _categoryService.DeleteAsync(selectedCategoryId.Value);
                    MessageBox.Show("Category eliminada exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    await LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error eliminando categoria: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ConnectValidationEvents()
        {
            // Connect validation events
            txtName.Validating += txtName_Validating;
            txtName.Validated += txtName_Validated;
        }
    }
}
