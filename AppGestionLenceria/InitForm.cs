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

        private void CloseAllChildForms()
        {
            // Create a copy of the MdiChildren collection to avoid collection modification issues
            Form[] childForms = this.MdiChildren.ToArray();

            // Close all open child forms
            foreach (Form childForm in childForms)
            {
                childForm.Close();
            }
        }

        private void OpenChildForm<T>(T form) where T : Form
        {
            // Close all existing child forms
            CloseAllChildForms();

            // Set MDI parent and show the new form
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SupplierManagementForm(ServiceProvider));            
        }

        private void categoriasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CategoryManagementForm(ServiceProvider));            
        }

        private void tamañosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SizeManagementForm(ServiceProvider));            
        }

        private void coloresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ColorManagementForm(ServiceProvider));            
        }

        private void gestionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductManagementForm(ServiceProvider));            
        }
    }
}
