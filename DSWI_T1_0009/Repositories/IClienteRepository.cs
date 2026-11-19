
using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Repositories
{
    public interface IClienteRepository
    {
        // Métodos de consulta
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);

        // Métodos de mantenimiento
        Task<IReadOnlyList<Cliente>> ListarAsync();
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Cliente cliente);
        Task<bool> EditarAsync(Cliente cliente);
    }
}
