using CORE.Dto.Requests;
using CORE.Dto.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.BAL.Interfaces
{
    public interface ICustomerAppService
    {
        Task<int> AddAsync(CustomerRequestDto obj);
        Task DeleteAsync(int id);
        Task<int> UpdateAsync(CustomerRequestDto obj);
        Task<CustomerResponse> GetAsync(int id);
        Task<IEnumerable<CustomerDtoResponse>> GetAllAsync();
    }
}
