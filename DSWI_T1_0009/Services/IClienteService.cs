using DSWI_T1_0009.Models;
namespace DSWI_T1_0009.Services;
public interface IClienteService { Task<IReadOnlyList<Cliente>> ListarAsync(); Task<Cliente?> ObtenerPorIdAsync(int id); Task CrearAsync(Cliente cliente); Task<bool> EditarAsync(Cliente cliente); }
