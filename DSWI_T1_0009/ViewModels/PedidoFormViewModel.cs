using System.ComponentModel.DataAnnotations;
using DSWI_T1_0009.Models;
namespace DSWI_T1_0009.ViewModels;
public class PedidoFormViewModel
{
    public int PedidoId { get; set; }
    [Required, DataType(DataType.Date)] public DateOnly FechaPedido { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    [Range(typeof(decimal), "0.01", "99999999.99", ParseLimitsInInvariantCulture = true)] public decimal Monto { get; set; }
    [Required, StringLength(50)] public string Estado { get; set; } = "Pendiente";
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un cliente.")] public int ClienteId { get; set; }
    public IEnumerable<Cliente> Clientes { get; set; } = [];
}
