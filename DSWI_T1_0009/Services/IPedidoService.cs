
using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Services
{
    public interface IPedidoService
    {
        Task<List<Pedido>> GetAllAsync();

        Task<Pedido?> GetByIdAsync(int id);
    }
}
