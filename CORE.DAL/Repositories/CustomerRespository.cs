using CORE.DAL.Common;
using CORE.DAL.Context;
using CORE.DAL.Interfaces;
using CORE.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.DAL.Repositories
{
    public class CustomerRespository : Repository<Customer>, ICustomersRepository
    {
        private readonly customerContext Context;

        public CustomerRespository(customerContext context) : base(context)
        {
            Context = context;
        }

        public async Task<int> AddAsync(Customer obj)
        {
            await Add(obj);
            return obj.Customerid;
        }

        public async Task DeleteAsync(int id)
        {
            Context.RemoveRange(Context.Customers.Where(x => x.Customerid == id));
            await Context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Customer obj)
        {
            await Update(obj);
            return obj.Customerid;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await Context.Customers
                .OrderBy(x => x.Customerid)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await Context.Customers
                .OrderBy(x => x.Customerid)
                .Where(x => x.Customerid == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
