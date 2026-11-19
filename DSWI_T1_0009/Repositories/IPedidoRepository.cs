
using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Repositories
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetAllAsync();

        Task<Pedido?> GetByIdAsync(int id);
    }
}
