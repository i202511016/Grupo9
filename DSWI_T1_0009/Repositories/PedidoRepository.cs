
using System.Data;
using DSWI_T1_0009.Data;
using DSWI_T1_0009.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_0009.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EmpresaDbContext _context;

        public PedidoRepository(EmpresaDbContext context)
        {
            _context = context;
        }

        // Consultas de tu implementación
        public async Task<List<Pedido>> GetAllAsync()
        {
            return (await ListarAsync()).ToList();
        }

        public Task<Pedido?> GetByIdAsync(int id)
        {
            return ObtenerPorIdAsync(id);
        }

        // Listar pedidos mediante procedimiento almacenado
        public async Task<IReadOnlyList<Pedido>> ListarAsync()
        {
            var lista = await _context.Pedidos
                .FromSqlRaw("EXEC dbo.sp_ListarPedidos")
                .AsNoTracking()
                .ToListAsync();

            var clientes = await _context.Clientes
                .FromSqlRaw("EXEC dbo.sp_ListarClientes")
                .AsNoTracking()
                .ToListAsync();

            foreach (var pedido in lista)
            {
                pedido.Cliente = clientes.FirstOrDefault(
                    c => c.ClienteId == pedido.ClienteId)!;
            }

            return lista;
        }

        public async Task<Pedido?> ObtenerPorIdAsync(int id)
        {
            var pedidos = await _context.Pedidos
                .FromSqlRaw(
                    "EXEC dbo.sp_ObtenerPedidoPorId @PedidoID",
                    new SqlParameter("@PedidoID", SqlDbType.Int)
                    {
                        Value = id
                    })
                .AsNoTracking()
                .ToListAsync();

            return pedidos.FirstOrDefault();
        }

        public async Task CrearAsync(Pedido pedido)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.sp_CrearPedido @FechaPedido, @Monto, @Estado, @ClienteID",
                new SqlParameter("@FechaPedido", SqlDbType.Date)
                {
                    Value = pedido.FechaPedido.ToDateTime(TimeOnly.MinValue)
                },
                new SqlParameter("@Monto", SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Value = pedido.Monto
                },
                new SqlParameter("@Estado", SqlDbType.NVarChar, 50)
                {
                    Value = pedido.Estado
                },
                new SqlParameter("@ClienteID", SqlDbType.Int)
                {
                    Value = pedido.ClienteId
                });
        }

        public async Task<bool> EditarAsync(Pedido pedido)
        {
            if (await ObtenerPorIdAsync(pedido.PedidoId) is null)
                return false;

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.sp_EditarPedido @PedidoID, @FechaPedido, @Monto, @Estado, @ClienteID",
                new SqlParameter("@PedidoID", SqlDbType.Int)
                {
                    Value = pedido.PedidoId
                },
                new SqlParameter("@FechaPedido", SqlDbType.Date)
                {
                    Value = pedido.FechaPedido.ToDateTime(TimeOnly.MinValue)
                },
                new SqlParameter("@Monto", SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Value = pedido.Monto
                },
                new SqlParameter("@Estado", SqlDbType.NVarChar, 50)
                {
                    Value = pedido.Estado
                },
                new SqlParameter("@ClienteID", SqlDbType.Int)
                {
                    Value = pedido.ClienteId
                });

            return true;
        }
    }
}
