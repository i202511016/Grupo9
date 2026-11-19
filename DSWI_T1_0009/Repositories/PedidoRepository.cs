
using DSWI_T1_0009.Data;
using DSWI_T1_0009.Models;
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

        public async Task<List<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _context.Pedidos
                .FirstOrDefaultAsync(p => p.PedidoId == id);
        }
    }
}
