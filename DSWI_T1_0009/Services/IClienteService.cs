
using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Services
{
    public interface IClienteService
    {
        // Métodos de consulta de tu implementación
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);

        // Métodos de mantenimiento de tu compañero
        Task<IReadOnlyList<Cliente>> ListarAsync();
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Cliente cliente);
        Task<bool> EditarAsync(Cliente cliente);
    }
}
