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
using System.Xml.Linq;

namespace AppGestionLenceria
{
    public partial class SupplierManagementForm : Form
    {
        private readonly ISupplierService _supplierService;
        private IEnumerable<Supplier> _suppliers = Enumerable.Empty<Supplier>();
        private int? selectedSupplierId = null;

        protected IServiceProvider ServiceProvider { get; }
        public SupplierManagementForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _supplierService = GetService<ISupplierService>();
            InitializeComponent();
        }

        private async Task LoadData()
        {
            //load suppliers list
            try
            {
                _suppliers = await _supplierService.GetAllAsync();
                dgvSuppliers.DataSource = _suppliers.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error Loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void SupplierManagementForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtName.Text.Length < 1)
                {
                    MessageBox.Show("The Supplier needs a name, please insert one", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(_suppliers.Any(s => s.Name.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase))) 
                {
                    MessageBox.Show("The Supplier already exist, please put another name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isUpdating = selectedSupplierId.HasValue;

                

                if (isUpdating)
                {
                    int supplierId = selectedSupplierId.Value;
                    var supplier = await _supplierService.GetByIdAsync(supplierId);
                    supplier.Name = txtName.Text;
                    await _supplierService.UpdateAsync(supplier);
                }
                else
                {
                    var supplier = new Supplier
                    {
                        Name = txtName.Text,
                    };

                    supplier = await _supplierService.CreateAsync(supplier);                    
                     
                    //selectedSupplierId = supplier.Id;
                }

                MessageBox.Show("Supplier saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data
                await LoadData();
                selectedSupplierId = null;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error saving supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!selectedSupplierId.HasValue)
            {
                MessageBox.Show("Please select a supplier to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _supplierService.DeleteAsync(selectedSupplierId.Value);
                    MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    await LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void dgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                selectedSupplierId = (int)dgvSuppliers.SelectedRows[0].Cells["Id"].Value;

                var supplier = await _supplierService.GetByIdAsync(selectedSupplierId.Value);

                txtName.Text = supplier.Name;
            }
        }

        private void ClearForm()
        {
            selectedSupplierId = null;
            txtName.Text = string.Empty;
        }
    }
}
