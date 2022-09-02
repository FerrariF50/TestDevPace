using CORE.Dto.Requests;
using CORE.Dto.Responses;
using Customer.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.BAL.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        public Task<int> AddAsync(CustomerRequestDto obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDtoResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponse> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(CustomerRequestDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
