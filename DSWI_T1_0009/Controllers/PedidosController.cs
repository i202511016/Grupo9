
using DSWI_T1_0009.Models;
using DSWI_T1_0009.Services;
using DSWI_T1_0009.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_0009.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidos;
        private readonly IClienteService _clientes;

        public PedidosController(
            IPedidoService pedidos,
            IClienteService clientes)
        {
            _pedidos = pedidos;
            _clientes = clientes;
        }

        // Listar pedidos: conserva tu implementación
        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidos.GetAllAsync();
            return View(pedidos);
        }

        // Mostrar formulario de creación
        public async Task<IActionResult> Crear()
        {
            return View(await CargarClientes(new PedidoFormViewModel()));
        }

        // Registrar pedido
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(PedidoFormViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(await CargarClientes(vm));

            await _pedidos.CrearAsync(Mapear(vm));

            TempData["Mensaje"] = "Pedido registrado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // Mostrar formulario de edición
        public async Task<IActionResult> Editar(int id)
        {
            var pedido = await _pedidos.ObtenerPorIdAsync(id);

            if (pedido is null)
                return NotFound();

            var vm = new PedidoFormViewModel
            {
                PedidoId = pedido.PedidoId,
                FechaPedido = pedido.FechaPedido,
                Monto = pedido.Monto,
                Estado = pedido.Estado,
                ClienteId = pedido.ClienteId
            };

            return View(await CargarClientes(vm));
        }

        // Actualizar pedido
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, PedidoFormViewModel vm)
        {
            if (id != vm.PedidoId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(await CargarClientes(vm));

            if (!await _pedidos.EditarAsync(Mapear(vm)))
                return NotFound();

            TempData["Mensaje"] = "Pedido actualizado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // Cargar clientes para el desplegable
        private async Task<PedidoFormViewModel> CargarClientes(
            PedidoFormViewModel vm)
        {
            vm.Clientes = await _clientes.ListarAsync();
            return vm;
        }

        // Convertir ViewModel a Pedido
        private static Pedido Mapear(PedidoFormViewModel vm)
        {
            return new Pedido
            {
                PedidoId = vm.PedidoId,
                FechaPedido = vm.FechaPedido,
                Monto = vm.Monto,
                Estado = vm.Estado,
                ClienteId = vm.ClienteId
            };
        }
    }
}
