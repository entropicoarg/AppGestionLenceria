using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionLenceria
{
    public class BaseForm : Form
    {
        protected IServiceProvider ServiceProvider { get; }

        public BaseForm()
        {

        }
        public BaseForm(IServiceProvider serviceProvider) : base()
        {
            ServiceProvider = serviceProvider;
        }

        protected T GetService<T>() where T : class
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
