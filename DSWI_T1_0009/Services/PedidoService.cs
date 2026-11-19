using DSWI_T1_0009.Models;
using DSWI_T1_0009.Repositories;
namespace DSWI_T1_0009.Services;
public class PedidoService(IPedidoRepository repo) : IPedidoService
{
    public Task<IReadOnlyList<Pedido>> ListarAsync() => repo.ListarAsync();
    public Task<Pedido?> ObtenerPorIdAsync(int id) => repo.ObtenerPorIdAsync(id);
    public Task CrearAsync(Pedido pedido) => repo.CrearAsync(pedido);
    public Task<bool> EditarAsync(Pedido pedido) => repo.EditarAsync(pedido);
}
