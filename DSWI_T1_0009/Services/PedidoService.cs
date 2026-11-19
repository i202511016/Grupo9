
using DSWI_T1_0009.Models;
using DSWI_T1_0009.Repositories;

namespace DSWI_T1_0009.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Pedido>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
