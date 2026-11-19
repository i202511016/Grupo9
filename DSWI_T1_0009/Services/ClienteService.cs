using DSWI_T1_0009.Models;
using DSWI_T1_0009.Repositories;

namespace DSWI_T1_0009.Services;

public class ClienteService(IClienteRepository repository) : IClienteService
{
    public Task<List<Cliente>> ObtenerTodosAsync() => repository.ObtenerTodosAsync();

    public Task<Cliente?> ObtenerPorIdAsync(int id) => repository.ObtenerPorIdAsync(id);
}
