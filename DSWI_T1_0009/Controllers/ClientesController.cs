
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
    }
}
