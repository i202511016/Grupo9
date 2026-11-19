using DSWI_T1_0009.Models;
using DSWI_T1_0009.Repositories;
namespace DSWI_T1_0009.Services;
public class ClienteService(IClienteRepository repo) : IClienteService
{
    public Task<IReadOnlyList<Cliente>> ListarAsync() => repo.ListarAsync();
    public Task<Cliente?> ObtenerPorIdAsync(int id) => repo.ObtenerPorIdAsync(id);
    public Task CrearAsync(Cliente cliente) => repo.CrearAsync(cliente);
    public Task<bool> EditarAsync(Cliente cliente) => repo.EditarAsync(cliente);
}
