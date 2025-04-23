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
    }
}
