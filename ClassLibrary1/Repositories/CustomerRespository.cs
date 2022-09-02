using CORE.DAL.Common;
using CORE.DAL.Context;
using CORE.DAL.Interfaces;
using CORE.DAL.Models;
using System.Threading.Tasks;

namespace CORE.DAL.Repositories
{
    public class CustomerRespository : Repository<Customer>, ICustomersRepository
    {
        public CustomerRespository(customersContext context) : base(context)
        {
        }

        public async Task<int> AddAsync(Customer obj)
        {
            await Add(obj);
            return obj.Customerid;
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(id);
        }

        public async Task<int> UpdateAsync(Customer obj)
        {
            await UpdateAsync(obj);
            return obj.Customerid;
        }
    }
}
