using DSWI_T1_0009.Data;
using DSWI_T1_0009.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_0009.Repositories;

public class ClienteRepository(EmpresaDbContext context) : IClienteRepository
{
    public Task<List<Cliente>> ObtenerTodosAsync() =>
        context.Clientes.AsNoTracking().ToListAsync();

    public Task<Cliente?> ObtenerPorIdAsync(int id) =>
        context.Clientes.AsNoTracking().FirstOrDefaultAsync(cliente => cliente.ClienteId == id);
}
