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

namespace AppGestionLenceria
{
    public partial class SupplierManagementForm : Form
    {
        private readonly ISupplierService _supplierService;
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
            var suppliers = await _supplierService.GetAllAsync();
            dgvSuppliers.DataSource = suppliers;
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var supplier = new Supplier
            {
                Name = txtName.Text
            },

        }
    }
}
