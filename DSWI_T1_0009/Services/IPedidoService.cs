using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Services;

public interface IPedidoService
{
    Task<List<Pedido>> ObtenerTodosAsync();
    Task<Pedido?> ObtenerPorIdAsync(int id);
}
