using DSWI_T1_0009.Models;
using DSWI_T1_0009.Repositories;

namespace DSWI_T1_0009.Services;

public class PedidoService(IPedidoRepository repository) : IPedidoService
{
    public Task<List<Pedido>> ObtenerTodosAsync() => repository.ObtenerTodosAsync();

    public Task<Pedido?> ObtenerPorIdAsync(int id) => repository.ObtenerPorIdAsync(id);
}
