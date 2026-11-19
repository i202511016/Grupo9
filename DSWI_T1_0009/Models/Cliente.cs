using System.ComponentModel.DataAnnotations;
namespace DSWI_T1_0009.Models;
public partial class Cliente
{
    public int ClienteId { get; set; }
    [Required, StringLength(100)] public string Nombre { get; set; } = null!;
    [Required, EmailAddress, StringLength(100)] public string CorreoElectronico { get; set; } = null!;
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
