using DSWI_T1_0009.Data;
using DSWI_T1_0009.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_0009.Repositories;

public class PedidoRepository(EmpresaDbContext context) : IPedidoRepository
{
    public Task<List<Pedido>> ObtenerTodosAsync() =>
        context.Pedidos.AsNoTracking().Include(pedido => pedido.Cliente).ToListAsync();

    public Task<Pedido?> ObtenerPorIdAsync(int id) =>
        context.Pedidos.AsNoTracking()
            .Include(pedido => pedido.Cliente)
            .FirstOrDefaultAsync(pedido => pedido.PedidoId == id);
}
