
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

        // Métodos de consulta de tu implementación
        public Task<List<Pedido>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Pedido?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        // Métodos de mantenimiento de tu compañero
        public Task<IReadOnlyList<Pedido>> ListarAsync()
        {
            return _repository.ListarAsync();
        }

        public Task<Pedido?> ObtenerPorIdAsync(int id)
        {
            return _repository.ObtenerPorIdAsync(id);
        }

        public Task CrearAsync(Pedido pedido)
        {
            return _repository.CrearAsync(pedido);
        }

        public Task<bool> EditarAsync(Pedido pedido)
        {
            return _repository.EditarAsync(pedido);
        }
    }
}
