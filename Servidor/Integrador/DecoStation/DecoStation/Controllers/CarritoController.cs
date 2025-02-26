using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DecoStation.Data;
using DecoStation.Models;

namespace DecoStation.Controllers
{
    public class CarritoController : Controller
    {
        private readonly DecoStationContexto _context;

        public CarritoController(DecoStationContexto context)
        {
            _context = context;
        }

        // GET: Carrito/Index/5
        public async Task<IActionResult> Index()
        {
            int? id = HttpContext.Session.GetInt32("NumPedido");
            if (id == null)
            {
                return RedirectToAction("Vacio");
            }

            var pedido = await _context.Orders
                .Include(c => c.User)
                .Include(e => e.Condition)
                .Include(p => p.Detalles)
                .ThenInclude(lp => lp.Producto)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pedido == null)
            {
                return RedirectToAction("Vacio");
            }
            bool containsLineasPedido = (pedido.Detalles.Count == 0) ? false : true;

            if (!containsLineasPedido)
            {
                return RedirectToAction("Vacio");
            }
            return View(pedido);

        }

        // GET: Carrito/Vacio
        public async Task<IActionResult> Vacio()
        {
            return View();
        }

        // GET: Carrito/ActualizarCantidad/5
        [HttpGet]
        public async Task<IActionResult> AumentarCantidad(int id)
        {

            var detalle = await _context.Details.FindAsync(id);

            if (detalle == null)
            {
                return NotFound();
            }

            detalle.Quantity++;
            _context.Update(detalle);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Carrito");
        }

        // GET: Carrito/RestarCantidad/5
        [HttpGet]
        public async Task<IActionResult> RestarCantidad(int id)
        {

            var lineaPedido = await _context.Details.FindAsync(id);

            if (lineaPedido == null)
            {
                return NotFound();
            }

            if (lineaPedido.Quantity > 1)
            {
                lineaPedido.Quantity--;
                _context.Update(lineaPedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Carrito");
        }



        // POST: Carrito/EliminarProducto/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var lineaPedido = await _context.Details.FindAsync(id);
            if (lineaPedido == null)
            {
                return NotFound();
            }

            _context.Details.Remove(lineaPedido);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { id = lineaPedido.OrderId });
        }

        // GET: Carrito/AgregarCarrito/5
        public async Task<IActionResult> ConfirmarPedido(int id)
        {
            // Buscar el pedido por Id
            var pedido = await _context.Orders
                .Include(p => p.Detalles) 
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                return RedirectToAction("Vacio", "Carrito");
            }

            if (pedido.Detalles == null || !pedido.Detalles.Any())
            {
                TempData["ErrorMessage"] = "El carrito está vacío, no se puede confirmar el pedido.";
                return RedirectToAction("Vacio", "Carrito");
            }

            var estadoConfirmado = await _context.Conditions
                .FirstOrDefaultAsync(e => e.Description == "Confirmado");
            if (estadoConfirmado != null)
            {
                pedido.ConditionId = estadoConfirmado.Id;
                pedido.Confirmed = DateTime.Now;
                _context.Update(pedido);
                await _context.SaveChangesAsync();
            }

            HttpContext.Session.Remove("NumPedido");

            return RedirectToAction("Index", "Escaparate");
        }

    }
}
