using System.Data;
using DSWI_T1_0009.Data;
using DSWI_T1_0009.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace DSWI_T1_0009.Repositories;
public class PedidoRepository(EmpresaDbContext db) : IPedidoRepository
{
    public async Task<IReadOnlyList<Pedido>> ListarAsync()
    {
        var lista = await db.Pedidos.FromSqlRaw("EXEC dbo.sp_ListarPedidos").AsNoTracking().ToListAsync();
        var clientes = await db.Clientes.FromSqlRaw("EXEC dbo.sp_ListarClientes").AsNoTracking().ToListAsync();
        foreach (var pedido in lista) pedido.Cliente = clientes.FirstOrDefault(c => c.ClienteId == pedido.ClienteId)!;
        return lista;
    }
    public async Task<Pedido?> ObtenerPorIdAsync(int id) => (await db.Pedidos.FromSqlRaw("EXEC dbo.sp_ObtenerPedidoPorId @PedidoID", new SqlParameter("@PedidoID", SqlDbType.Int) { Value = id }).AsNoTracking().ToListAsync()).FirstOrDefault();
    public async Task CrearAsync(Pedido p) => await db.Database.ExecuteSqlRawAsync("EXEC dbo.sp_CrearPedido @FechaPedido, @Monto, @Estado, @ClienteID", new SqlParameter("@FechaPedido", SqlDbType.Date) { Value = p.FechaPedido.ToDateTime(TimeOnly.MinValue) }, new SqlParameter("@Monto", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = p.Monto }, new SqlParameter("@Estado", SqlDbType.NVarChar, 50) { Value = p.Estado }, new SqlParameter("@ClienteID", SqlDbType.Int) { Value = p.ClienteId });
    public async Task<bool> EditarAsync(Pedido p)
    {
        if (await ObtenerPorIdAsync(p.PedidoId) is null) return false;
        await db.Database.ExecuteSqlRawAsync("EXEC dbo.sp_EditarPedido @PedidoID, @FechaPedido, @Monto, @Estado, @ClienteID", new SqlParameter("@PedidoID", SqlDbType.Int) { Value = p.PedidoId }, new SqlParameter("@FechaPedido", SqlDbType.Date) { Value = p.FechaPedido.ToDateTime(TimeOnly.MinValue) }, new SqlParameter("@Monto", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = p.Monto }, new SqlParameter("@Estado", SqlDbType.NVarChar, 50) { Value = p.Estado }, new SqlParameter("@ClienteID", SqlDbType.Int) { Value = p.ClienteId });
        return true;
    }
}


