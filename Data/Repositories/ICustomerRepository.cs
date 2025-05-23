﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetWithSalesAsync(int id);
    }
}
