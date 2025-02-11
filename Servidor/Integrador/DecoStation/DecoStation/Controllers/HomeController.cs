using System.Diagnostics;
using DecoStation.Data;
using DecoStation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecoStation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DecoStationContexto _context;

        public HomeController(ILogger<HomeController> logger, DecoStationContexto context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Busca al usuario actual. Si existe, activa la 
            // vista (View) y en caso contrario, se redirige para crear al usuario. 
            string? emailUsuario = User.Identity.Name;
            Usuario? empleado = _context.Users.Where(e => e.Email == emailUsuario)
                                  .FirstOrDefault();
            if (User.Identity.IsAuthenticated &&
                User.IsInRole("Usuario") &&
                empleado == null)
            {
                return RedirectToAction("Create", "MisDatos");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
