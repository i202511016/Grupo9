using System.Data;
using DSWI_T1_0009.Data;
using DSWI_T1_0009.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace DSWI_T1_0009.Repositories;
public class ClienteRepository(EmpresaDbContext db) : IClienteRepository
{
    public async Task<IReadOnlyList<Cliente>> ListarAsync() => await db.Clientes.FromSqlRaw("EXEC dbo.sp_ListarClientes").AsNoTracking().ToListAsync();
    public async Task<Cliente?> ObtenerPorIdAsync(int id) => (await db.Clientes.FromSqlRaw("EXEC dbo.sp_ObtenerClientePorId @ClienteID", new SqlParameter("@ClienteID", SqlDbType.Int) { Value = id }).AsNoTracking().ToListAsync()).FirstOrDefault();
    public async Task CrearAsync(Cliente c) => await db.Database.ExecuteSqlRawAsync("EXEC dbo.sp_CrearCliente @Nombre, @CorreoElectronico", new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = c.Nombre }, new SqlParameter("@CorreoElectronico", SqlDbType.NVarChar, 100) { Value = c.CorreoElectronico });
    public async Task<bool> EditarAsync(Cliente c)
    {
        if (await ObtenerPorIdAsync(c.ClienteId) is null) return false;
        await db.Database.ExecuteSqlRawAsync("EXEC dbo.sp_EditarCliente @ClienteID, @Nombre, @CorreoElectronico", new SqlParameter("@ClienteID", SqlDbType.Int) { Value = c.ClienteId }, new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = c.Nombre }, new SqlParameter("@CorreoElectronico", SqlDbType.NVarChar, 100) { Value = c.CorreoElectronico });
        return true;
    }
}


