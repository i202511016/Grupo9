using DSWI_T1_0009.Services;
using Microsoft.AspNetCore.Mvc;
{
    {
    }
    {
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
