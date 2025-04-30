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
    public partial class CustomerManagementForm : Form
    {
        private readonly ICustomerService _customerService;
        private IEnumerable<Customer> _customers = Enumerable.Empty<Customer>();
        private BindingSource _bindingSource = new BindingSource();
        private DataTable _customerDataTable;

        private int? _selectedCustomerId = null;

        protected IServiceProvider ServiceProvider { get; }
        public CustomerManagementForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _customerService = GetService<ICustomerService>();
            InitializeComponent();
        }

        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        private async Task<DataTable> ConvertCustomerToDataTableAsync(IEnumerable<Customer> customers)
        {

            var customerDataTable = new DataTable();
            // Add columns
            customerDataTable.Columns.Add("Id", typeof(int));
            customerDataTable.Columns.Add("Nombre", typeof(string));
            customerDataTable.Columns.Add("Telefono", typeof(string));
            customerDataTable.Columns.Add("E-Mail", typeof(string));
            customerDataTable.Columns.Add("Redes Sociales", typeof(string));
          

            // Add rows for each product
            foreach (var customer in _customers)
            {
                var row = customerDataTable.NewRow();
                row["Id"] = customer.Id;
                row["Nombre"] = customer.Name;
                row["Telefono"] = customer.Phone ?? string.Empty;
                row["E-Mail"] = customer.Email ?? string.Empty;
                row["Redes Sociales"] = customer.SocialMedia ?? string.Empty;


                customerDataTable.Rows.Add(row);
            }


            return customerDataTable;
        }

        private async Task LoadData()
        {
            try
            {
                _customers = await _customerService.GetAllAsync();
                _customerDataTable = await ConvertCustomerToDataTableAsync(_customers);
                _bindingSource.DataSource = _customerDataTable;

                dgvCustomers.DataSource = _bindingSource;
            }            
            catch (Exception ex)
            {

                MessageBox.Show($"Error Loading sizes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEMail.Text = string.Empty;
            txtSocialMedia.Text = string.Empty;
            _selectedCustomerId = null;
        }

        private async void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            await LoadData();
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
                    MessageBox.Show("The Customer needs a name, please insert one", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_customers.Any(s => s.Name.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("The Customer already exist, please put another name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isUpdating = _selectedCustomerId.HasValue;



                if (isUpdating)
                {
                    int customerId = _selectedCustomerId.Value;
                    var customer = await _customerService.GetByIdAsync(customerId);
                    customer.Name = txtName.Text;
                    customer.Phone = txtPhone.Text;
                    customer.Email = txtEMail.Text;
                    customer.SocialMedia = txtSocialMedia.Text;

                    await _customerService.UpdateAsync(customer);
                }
                else
                {
                    var customer = new Customer()
                    {
                        Name = txtName.Text,
                        Phone = txtPhone.Text,
                        Email = txtEMail.Text,
                        SocialMedia = txtSocialMedia.Text
                };

                    customer = await _customerService.CreateAsync(customer);

                }

                MessageBox.Show("Customer saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data
                await LoadData();
                _selectedCustomerId = null;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error saving Customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedCustomerId.HasValue)
            {
                MessageBox.Show("Please select a Customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this Customer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _customerService.DeleteAsync(_selectedCustomerId.Value);
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    await LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting Customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
