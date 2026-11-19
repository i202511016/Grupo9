
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

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
