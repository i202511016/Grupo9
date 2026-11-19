using Microsoft.AspNetCore.Mvc;
using DSWI_T1_0009.Models;

namespace DSWI_T1_0009.Controllers
{
    public class GimnasioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new MembresiaGimnasioModel());
        }

        [HttpPost]
        public IActionResult Index(MembresiaGimnasioModel model)
        {
            if (model.Edad >= 0 && model.Meses > 0)
            {
                decimal tarifaBase = model.Edad < 18 ? 20m : (model.Edad <= 59 ? 35m : 25m);

                decimal porcentajeDescuento = model.Meses switch
                {
                    3 => 0.05m,
                    6 => 0.10m,
                    12 => 0.20m,
                    _ => 0m
                };

                decimal subtotal = tarifaBase * model.Meses;
                decimal descuento = subtotal * porcentajeDescuento;

                model.TarifaBase = tarifaBase;
                model.Descuento = descuento;
                model.TotalPagar = subtotal - descuento;
            }
            return View(model);
        }
    }
}