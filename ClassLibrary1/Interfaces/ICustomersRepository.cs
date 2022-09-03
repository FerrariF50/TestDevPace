﻿using CORE.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CORE.DAL.Interfaces
{
    public interface ICustomersRepository
    {
        Task<int> AddAsync(Customer obj);
        Task<int> UpdateAsync(Customer obj);
        Task DeleteAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetAsync(int id);
    }
}
