
using DSWI_T1_0009.Data;
using DSWI_T1_0009.Models;
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

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }
    }
}
