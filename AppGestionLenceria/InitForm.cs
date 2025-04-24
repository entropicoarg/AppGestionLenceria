using AppGestionLenceria;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class InitForm : Form
    {
        protected IServiceProvider ServiceProvider { get; }
        public InitForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            InitializeComponent();
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierManagementForm supplierForm = new SupplierManagementForm(ServiceProvider);
            supplierForm.MdiParent = this;
            supplierForm.Show();
        }

        private void categoriasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CategoryManagementForm categoryManagementForm = new CategoryManagementForm(ServiceProvider);
            categoryManagementForm.MdiParent = this;
            categoryManagementForm.Show();
        }

        private void tamañosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SizeManagementForm sizeManagementForm = new SizeManagementForm(ServiceProvider);
            sizeManagementForm.MdiParent = this;
            sizeManagementForm.Show();
        }

        private void coloresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorManagementForm colorManagementForm = new ColorManagementForm(ServiceProvider);
            colorManagementForm.MdiParent = this;
            colorManagementForm.Show();
        }

        private void gestionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductManagementForm productManagementForm = new ProductManagementForm(ServiceProvider);
            productManagementForm.MdiParent = this;
            productManagementForm.Show();
        }
    }
}
