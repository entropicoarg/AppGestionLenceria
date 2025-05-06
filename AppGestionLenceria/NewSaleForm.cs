using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
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
    public partial class NewSaleForm : Form
    {
        private readonly ICustomerService _customerService;
        private readonly ISaleService _saleService;
        private IEnumerable<Product> _products = Enumerable.Empty<Product>();

        protected IServiceProvider ServiceProvider { get; }
        public NewSaleForm(IEnumerable<Product> products, IServiceProvider serviceProvider)
        {
            _products = products;
            ServiceProvider = serviceProvider;
            _customerService = GetService<ICustomerService>();
            _saleService = GetService<ISaleService>();
            InitializeComponent();
        }

        private async void LoadCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaymentMethods()
        {
            cmbPaymentMethods.DataSource = Enum.GetValues(typeof(PaymentMethod));
        }

        private void NewSaleForm_Load(object sender, EventArgs e)
        {
            LoadPaymentMethods();
            LoadCustomers();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_products.Any())
            {
                try
                {
                    PaymentMethod selectedPaymentMethod = (PaymentMethod)cmbPaymentMethods.SelectedItem;
                    Customer selectedCustomer = (Customer)cmbCustomer.SelectedItem;
                    Sale newSale = new()
                    {
                        SaleDate = dateTimePicker1.Value,
                        PaymentMethod = selectedPaymentMethod,
                        PaymentMethodDetail = txtPaymentMethodDetail.Text,
                        TicketNumber = txtTicketNumber.Text,
                        InvoiceNumber = txtInvoiceNumber.Text,
                        CustomerId = selectedCustomer.Id,
                    };

                    // Create a list of SaleDetail with only the necessary information
                    List<SaleDetail> details = new List<SaleDetail>();

                    foreach (var product in _products)
                    {
                        SaleDetail newSaleDetail = new()
                        {
                            ProductId = product.Id,
                            Quantity = product.Quantity, // Assuming this is the quantity to be sold
                            UnitPrice = product.RoundedPrice
                        };
                        details.Add(newSaleDetail);
                    }

                    await _saleService.CreateAsync(newSale, details);

                    MessageBox.Show($"New sale created.",
                    "Sale Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating sale: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
