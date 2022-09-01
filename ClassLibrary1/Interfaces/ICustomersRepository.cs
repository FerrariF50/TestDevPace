using DevPace.CORE.DAL.Models;
using System.Threading.Tasks;

namespace CORE.DAL.Interfaces
{
    public interface ICustomersRepository
    {
        Task<int> AddAsync(Customer obj);
        Task<int> UpdateAsync(Customer obj);
        Task DeleteAsync(int id);
    }
}
