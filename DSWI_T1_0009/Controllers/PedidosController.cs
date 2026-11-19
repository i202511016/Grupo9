using DSWI_T1_0009.Models;
using DSWI_T1_0009.Services;
using DSWI_T1_0009.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace DSWI_T1_0009.Controllers;
public class PedidosController(IPedidoService pedidos, IClienteService clientes) : Controller
{
    public async Task<IActionResult> Index() => View(await pedidos.ListarAsync());
    public async Task<IActionResult> Crear() => View(await CargarClientes(new PedidoFormViewModel()));
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(PedidoFormViewModel vm)
    {
        if (!ModelState.IsValid) return View(await CargarClientes(vm));
        await pedidos.CrearAsync(Mapear(vm)); TempData["Mensaje"] = "Pedido registrado correctamente."; return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Editar(int id)
    {
        var p = await pedidos.ObtenerPorIdAsync(id); if (p is null) return NotFound();
        return View(await CargarClientes(new PedidoFormViewModel { PedidoId=p.PedidoId, FechaPedido=p.FechaPedido, Monto=p.Monto, Estado=p.Estado, ClienteId=p.ClienteId }));
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, PedidoFormViewModel vm)
    {
        if (id != vm.PedidoId) return BadRequest();
        if (!ModelState.IsValid) return View(await CargarClientes(vm));
        if (!await pedidos.EditarAsync(Mapear(vm))) return NotFound();
        TempData["Mensaje"] = "Pedido actualizado correctamente."; return RedirectToAction(nameof(Index));
    }
    private async Task<PedidoFormViewModel> CargarClientes(PedidoFormViewModel vm) { vm.Clientes = await clientes.ListarAsync(); return vm; }
    private static Pedido Mapear(PedidoFormViewModel vm) => new() { PedidoId=vm.PedidoId, FechaPedido=vm.FechaPedido, Monto=vm.Monto, Estado=vm.Estado, ClienteId=vm.ClienteId };
}
