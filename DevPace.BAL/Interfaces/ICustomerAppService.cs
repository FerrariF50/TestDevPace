using CORE.Dto.Dto;
using CORE.Dto.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.BAL.Interfaces
{
    public interface ICustomerAppService
    {
        Task<int> AddAsync(CustomerRequestDto obj);
        Task DeleteAsync(int id);
        Task<int> UpdateAsync(CustomerRequestDto obj);
        Task<CustomerDto> GetAsync(int id);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
    }
}
