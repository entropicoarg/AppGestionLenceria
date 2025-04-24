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
    public partial class ColorManagementForm : Form
    {
        private readonly IColorService _colorService;
        private IEnumerable<Domain.Entities.Color> _colors = Enumerable.Empty<Domain.Entities.Color>();
        private int? selectedColorId = null;

        protected IServiceProvider ServiceProvider { get; }
        public ColorManagementForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _colorService = GetService<IColorService>();
            InitializeComponent();
        }
        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        private void ColorManagementForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private async Task LoadData()
        {
            //load category list
            try
            {
                _colors = await _colorService.GetAllAsync();
                dgvColors.DataSource = _colors.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error Loading sizes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            selectedColorId = null;
            txtName.Text = string.Empty;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length < 1)
                {
                    MessageBox.Show("The Color needs a name, please insert one", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_colors.Any(s => s.Name.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("The Color already exist, please put another name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isUpdating = selectedColorId.HasValue;



                if (isUpdating)
                {
                    int colorId = selectedColorId.Value;
                    var color = await _colorService.GetByIdAsync(colorId);
                    color.Name = txtName.Text;
                    await _colorService.UpdateAsync(color);
                }
                else
                {
                    var color = new Domain.Entities.Color()
                    {
                        Name = txtName.Text,
                    };

                    color = await _colorService.CreateAsync(color);

                }

                MessageBox.Show("Color saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data
                await LoadData();
                selectedColorId = null;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error saving color: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!selectedColorId.HasValue)
            {
                MessageBox.Show("Please select a color to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this color?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _colorService.DeleteAsync(selectedColorId.Value);
                    MessageBox.Show("Color deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    await LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting color: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void dgvColors_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvColors.SelectedRows.Count > 0)
            {
                selectedColorId = (int)dgvColors.SelectedRows[0].Cells["Id"].Value;

                var color = await _colorService.GetByIdAsync(selectedColorId.Value);

                txtName.Text = color.Name;
            }
        }
    }
}
