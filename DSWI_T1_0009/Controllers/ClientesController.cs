
using DSWI_T1_0009.Models;
using DSWI_T1_0009.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_0009.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _service.GetAllAsync();
            return View(clientes);
        }

        public IActionResult Crear()
        {
            return View(new Cliente());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            await _service.CrearAsync(cliente);

            TempData["Mensaje"] = "Cliente registrado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var cliente = await _service.GetByIdAsync(id);

            return cliente is null ? NotFound() : View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(cliente);

            if (!await _service.EditarAsync(cliente))
                return NotFound();

            TempData["Mensaje"] = "Cliente actualizado correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}
