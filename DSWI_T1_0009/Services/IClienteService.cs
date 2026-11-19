using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Services;

public interface IClienteService
{
    Task<List<Cliente>> ObtenerTodosAsync();
    Task<Cliente?> ObtenerPorIdAsync(int id);
}
