using DSWI_T1_0009.Models;
using DSWI_T1_0009.Services;
using Microsoft.AspNetCore.Mvc;
namespace DSWI_T1_0009.Controllers;
public class ClientesController(IClienteService service) : Controller
{
    public async Task<IActionResult> Index() => View(await service.ListarAsync());
    public IActionResult Crear() => View(new Cliente());
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Cliente cliente)
    {
        if (!ModelState.IsValid) return View(cliente);
        await service.CrearAsync(cliente); TempData["Mensaje"] = "Cliente registrado correctamente."; return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Editar(int id)
    {
        var cliente = await service.ObtenerPorIdAsync(id); return cliente is null ? NotFound() : View(cliente);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, Cliente cliente)
    {
        if (id != cliente.ClienteId) return BadRequest();
        if (!ModelState.IsValid) return View(cliente);
        if (!await service.EditarAsync(cliente)) return NotFound();
        TempData["Mensaje"] = "Cliente actualizado correctamente."; return RedirectToAction(nameof(Index));
    }
}
