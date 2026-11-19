
using DSWI_T1_0009.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_0009.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoService _service;

        public PedidosController(IPedidoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var pedidos = await _service.GetAllAsync();

            return View(pedidos);
        }
    }
}
