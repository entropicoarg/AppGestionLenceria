using Data.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SizeRepository : GenericRepository<Size>, ISizeRepository
    {
        public SizeRepository(LingerieDbContext context) : base(context)
        {
        }
    }
}
