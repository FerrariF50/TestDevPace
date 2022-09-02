using System.Threading.Tasks;

namespace CORE.DAL.Interfaces
{
    public interface ICustomersRepository
    {
        Task<int> AddAsync(Models.Customer obj);
        Task<int> UpdateAsync(Models.Customer obj);
        Task DeleteAsync(int id);
    }
}
