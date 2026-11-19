using Microsoft.AspNetCore.Mvc;
using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Controllers
{
    public class LlamadasController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LlamadaModel());
        }

        [HttpPost]
        public IActionResult Index(LlamadaModel model)
        {
            if (model.Minutos > 0)
            {
                model.TotalPagar = model.Minutos <= 5
                    ? 10m
                    : 10m + ((model.Minutos - 5) * 2m);
            }
            return View(model);
        }
    }
}