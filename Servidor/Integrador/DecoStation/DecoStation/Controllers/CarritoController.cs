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

        // GET: Carrito
        public async Task<IActionResult> Index()
        {
            // Recupera el número de pedido desde la sesión
            var strNumPedido = HttpContext.Session.GetString("NumPedido");
            if (string.IsNullOrEmpty(strNumPedido))
            {
                return RedirectToAction(nameof(CarritoVacio));
            }

            int pedidoId = int.Parse(strNumPedido);

            // Cargar el pedido actual con sus detalles
            var pedido = await _context.Orders
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Producto)
                .Include(o => o.Condition)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == pedidoId);

            if (pedido == null)
            {
                return RedirectToAction(nameof(CarritoVacio));
            }

            return View(pedido);
        }

        public IActionResult CarritoVacio()
        {
            return View();
        }

        // POST: Carrito/ConfirmarPedido/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarPedido(int id)
        {
            // Verifica que el pedido en sesión coincida con el id recibido
            var strNumPedido = HttpContext.Session.GetString("NumPedido");
            if (string.IsNullOrEmpty(strNumPedido) || int.Parse(strNumPedido) != id)
            {
                return RedirectToAction(nameof(CarritoVacio));
            }

            var pedido = await _context.Orders.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            // Actualizar el pedido: se establece la fecha de confirmación y se cambia el estado
            pedido.ConditionId = 2; // Por ejemplo, 2 representa "Confirmado"
            pedido.Confirmed = DateTime.Now;

            await _context.SaveChangesAsync();

            // Eliminar la variable de sesión para vaciar el carrito
            HttpContext.Session.Remove("NumPedido");

            // Redirigir al escaparate
            return RedirectToAction("Index", "Escaparate");
        }

        // POST: Carrito/EliminarLinea/10
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarLinea(int id)
        {
            // 'id' corresponde al Id del detalle a eliminar
            var detalle = await _context.Details.FindAsync(id);
            if (detalle != null)
            {
                _context.Details.Remove(detalle);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Carrito/MasCantidad/10
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MasCantidad(int id)
        {
            var detalle = await _context.Details.FindAsync(id);
            if (detalle != null)
            {
                detalle.Quantity = (detalle.Quantity ?? 0) + 1;
                // Recalcular el subtotal: se asume que el precio unitario se obtiene de Producto.Price
                if (detalle.Producto != null)
                {
                    detalle.Summary = detalle.Producto.Price * detalle.Quantity;
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Carrito/MenosCantidad/10
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MenosCantidad(int id)
        {
            var detalle = await _context.Details.FindAsync(id);
            if (detalle != null && (detalle.Quantity ?? 0) > 1)
            {
                detalle.Quantity = (detalle.Quantity ?? 0) - 1;
                if (detalle.Producto != null)
                {
                    detalle.Summary = detalle.Producto.Price * detalle.Quantity;
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: Carrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Orders
                .Include(p => p.Condition)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Carrito/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Description");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "CodigoPostal");
            return View();
        }

        // POST: Carrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeliveryTime,Confirmed,Prepared,Delivered,Paid,Returned,Cancelled,UserId,ConditionId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Description", pedido.ConditionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "CodigoPostal", pedido.UserId);
            return View(pedido);
        }

        // GET: Carrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Orders.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Description", pedido.ConditionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "CodigoPostal", pedido.UserId);
            return View(pedido);
        }

        // POST: Carrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeliveryTime,Confirmed,Prepared,Delivered,Paid,Returned,Cancelled,UserId,ConditionId")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Description", pedido.ConditionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "CodigoPostal", pedido.UserId);
            return View(pedido);
        }

        // GET: Carrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Orders
                .Include(p => p.Condition)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Carrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Orders.FindAsync(id); 
            if (pedido != null)
            {
                _context.Orders.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
