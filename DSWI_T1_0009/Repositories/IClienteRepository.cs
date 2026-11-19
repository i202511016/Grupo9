
using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync();

        Task<Cliente?> GetByIdAsync(int id);
    }
}
