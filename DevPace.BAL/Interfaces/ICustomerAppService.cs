using CORE.Dto.Requests;
using System.Threading.Tasks;

namespace Customer.BAL.Interfaces
{
    public interface ICustomerAppService
    {
        Task<int> AddAsync(CustomerRequestDto obj);
        Task DeleteAsync(int id);
        Task UpdateAsync(CustomerRequestDto obj);
        Task GetAsync(int id); 
    }
}
