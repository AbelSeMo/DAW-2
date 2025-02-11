using DecoStation.Data;
using DecoStation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecoStation.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class MisDatosController : Controller
    {
        private readonly DecoStationContexto _context;

        public MisDatosController(DecoStationContexto context)
        {
            _context = context;
        }

        // GET: MisDatos/Create 
        public IActionResult Create()
        {
            return View();
        }

        // POST: MisDatos/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        Create([Bind("Id,Fullname,Email,Direction,CodigoPostal,PhoneNumber")] Usuario usuario)
        {
            // Asignar el Email del usuario actual 
            usuario.Email = User.Identity.Name;

            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }

        // GET: MisDatos/Edit 
        public async Task<IActionResult> Edit()
        {
            // Se seleccionan los datos del empleado correspondiente al usuario actual 
            string? emailUsuario = User.Identity.Name;
            Usuario? usuario = await _context.Users
                  .Where(e => e.Email == emailUsuario)
                  .FirstOrDefaultAsync();
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: MisDatos/Edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Fullname,Email,Telefono,FechaNacimiento")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }
        private bool UsuarioExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
