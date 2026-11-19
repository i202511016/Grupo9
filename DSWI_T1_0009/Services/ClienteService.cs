
using DSWI_T1_0009.Models;
using DSWI_T1_0009.Repositories;

namespace DSWI_T1_0009.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        // Métodos de consulta
        public Task<List<Cliente>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Cliente?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        // Métodos de mantenimiento
        public Task<IReadOnlyList<Cliente>> ListarAsync()
        {
            return _repository.ListarAsync();
        }

        public Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            return _repository.ObtenerPorIdAsync(id);
        }

        public Task CrearAsync(Cliente cliente)
        {
            return _repository.CrearAsync(cliente);
        }

        public Task<bool> EditarAsync(Cliente cliente)
        {
            return _repository.EditarAsync(cliente);
        }
    }
}
