using DSWI_T1_0009.Models;
namespace DSWI_T1_0009.Services;
public interface IPedidoService { Task<IReadOnlyList<Pedido>> ListarAsync(); Task<Pedido?> ObtenerPorIdAsync(int id); Task CrearAsync(Pedido pedido); Task<bool> EditarAsync(Pedido pedido); }
