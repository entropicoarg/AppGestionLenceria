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
    public partial class SalesManagementForm : Form
    {
        private readonly IProductService _productService;
        protected IServiceProvider ServiceProvider { get; }
        public SalesManagementForm(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            InitializeComponent();
        }
    }
}
