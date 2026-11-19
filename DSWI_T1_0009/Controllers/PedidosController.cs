using DSWI_T1_0009.Services;
using DSWI_T1_0009.ViewModels;
using Microsoft.AspNetCore.Mvc;
{
    {
    }
    {
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
