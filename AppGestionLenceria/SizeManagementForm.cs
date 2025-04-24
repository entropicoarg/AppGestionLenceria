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
    public partial class SizeManagementForm : Form
    {
        private readonly ISizeService _sizeService;
        private IEnumerable<Domain.Entities.Size> _sizes = Enumerable.Empty<Domain.Entities.Size>();
        private int? selectedSizeId = null;

        protected IServiceProvider ServiceProvider { get; }
        public SizeManagementForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _sizeService = GetService<ISizeService>();
            InitializeComponent();
        }

        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        private async void SizeManagementForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            //load category list
            try
            {
                _sizes = await _sizeService.GetAllAsync();
                dgvSizes.DataSource = _sizes.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error Loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            selectedSizeId = null;
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
                    MessageBox.Show("The Size needs a name, please insert one", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_sizes.Any(s => s.Name.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("The Size already exist, please put another name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isUpdating = selectedSizeId.HasValue;



                if (isUpdating)
                {
                    int sizeId = selectedSizeId.Value;
                    var size = await _sizeService.GetByIdAsync(sizeId);
                    size.Name = txtName.Text;
                    await _sizeService.UpdateAsync(size);
                }
                else
                {
                    var size = new Domain.Entities.Size()
                    {
                        Name = txtName.Text,
                    };

                    size = await _sizeService.CreateAsync(size);

                }

                MessageBox.Show("Size saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data
                await LoadData();
                selectedSizeId = null;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error saving size: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!selectedSizeId.HasValue)
            {
                MessageBox.Show("Please select a size to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this size?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _sizeService.DeleteAsync(selectedSizeId.Value);
                    MessageBox.Show("Size deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    await LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting size: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void dgvSizes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSizes.SelectedRows.Count > 0)
            {
                selectedSizeId = (int)dgvSizes.SelectedRows[0].Cells["Id"].Value;

                var category = await _sizeService.GetByIdAsync(selectedSizeId.Value);

                txtName.Text = category.Name;
            }
        }
    }
}
