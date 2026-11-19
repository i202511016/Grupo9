using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Repositories;

public interface IPedidoRepository
{
    Task<List<Pedido>> ObtenerTodosAsync();
    Task<Pedido?> ObtenerPorIdAsync(int id);
}
