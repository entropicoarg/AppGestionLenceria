using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IPrintService
    {
        Task PrintProductTagAsync(Product product);
    }
}
