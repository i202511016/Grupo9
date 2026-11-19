
using System.Data;
using DSWI_T1_0009.Data;
using DSWI_T1_0009.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_0009.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EmpresaDbContext _context;

        public ClienteRepository(EmpresaDbContext context)
        {
            _context = context;
        }

        // Métodos de consulta de tu implementación
        public async Task<List<Cliente>> GetAllAsync()
        {
            return (await ListarAsync()).ToList();
        }

        public Task<Cliente?> GetByIdAsync(int id)
        {
            return ObtenerPorIdAsync(id);
        }

        // Métodos de mantenimiento mediante procedimientos almacenados
        public async Task<IReadOnlyList<Cliente>> ListarAsync()
        {
            return await _context.Clientes
                .FromSqlRaw("EXEC dbo.sp_ListarClientes")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            var clientes = await _context.Clientes
                .FromSqlRaw(
                    "EXEC dbo.sp_ObtenerClientePorId @ClienteID",
                    new SqlParameter("@ClienteID", SqlDbType.Int) { Value = id })
                .AsNoTracking()
                .ToListAsync();

            return clientes.FirstOrDefault();
        }

        public async Task CrearAsync(Cliente cliente)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.sp_CrearCliente @Nombre, @CorreoElectronico",
                new SqlParameter("@Nombre", SqlDbType.NVarChar, 100)
                {
                    Value = cliente.Nombre
                },
                new SqlParameter("@CorreoElectronico", SqlDbType.NVarChar, 100)
                {
                    Value = cliente.CorreoElectronico
                });
        }

        public async Task<bool> EditarAsync(Cliente cliente)
        {
            if (await ObtenerPorIdAsync(cliente.ClienteId) is null)
                return false;

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.sp_EditarCliente @ClienteID, @Nombre, @CorreoElectronico",
                new SqlParameter("@ClienteID", SqlDbType.Int)
                {
                    Value = cliente.ClienteId
                },
                new SqlParameter("@Nombre", SqlDbType.NVarChar, 100)
                {
                    Value = cliente.Nombre
                },
                new SqlParameter("@CorreoElectronico", SqlDbType.NVarChar, 100)
                {
                    Value = cliente.CorreoElectronico
                });

            return true;
        }
    }
}
