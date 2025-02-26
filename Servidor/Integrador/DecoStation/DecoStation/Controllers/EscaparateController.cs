using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DecoStation.Data;
using DecoStation.Models;
using Microsoft.AspNetCore.Authorization;

namespace DecoStation.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class EscaparateController : Controller
    {
        private readonly DecoStationContexto _context;

        public EscaparateController(DecoStationContexto context)
        {
            _context = context;
        }

        // GET: Escaparate
        public async Task<IActionResult> Index(int? id)
        {
            var categorias = await _context.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();
            ViewData["Categories"] = categorias;

            IQueryable<Producto> consulta = _context.Products.Include(p => p.Category);
            if (id == null)
            {
                consulta = consulta.Where(p => p.Escaparate == true);
            }
            else
            {
                consulta = consulta.Where(p => p.CategoriaID == id);
            }
            var productos = await consulta.ToListAsync();
            return View(productos);
        }

        // GET: Escaparate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var producto = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        // GET: Escaparate/Create
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Escaparate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Stock,Escaparate,Imagen,CategoriaID")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Name", producto.CategoriaID);
            return View(producto);
        }

        // GET: Escaparate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var producto = await _context.Products.FindAsync(id);
            if (producto == null) return NotFound();
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Name", producto.CategoriaID);
            return View(producto);
        }

        // POST: Escaparate/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Stock,Escaparate,Imagen,CategoriaID")] Producto producto)
        {
            if (id != producto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Name", producto.CategoriaID);
            return View(producto);
        }

        // GET: Escaparate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var producto = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        // POST: Escaparate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            if (producto != null) _context.Products.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        // GET: Escaparate/AgregarCarrito/5
        public async Task<IActionResult> AgregarCarrito(int id)
        {
            var producto = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        // POST: Escaparate/AgregarCarrito/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarCarritoPost(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            if (producto == null) return NotFound();

            int? NumPedido = HttpContext.Session.GetInt32("NumPedido");
            Pedido pedidoActual = null;

            if (NumPedido == null)
            {
                string userEmail = User.Identity.Name;
                var usuarioActual = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
                if (usuarioActual == null) return Unauthorized();

                pedidoActual = new Pedido
                {
                    DeliveryTime = DateTime.Now,
                    Confirmed = null,
                    Prepared = null,
                    Delivered = null,
                    Paid = null,
                    Returned = null,
                    Cancelled = null,
                    UserId = usuarioActual.Id,
                    ConditionId = 1  // "Pendiente"
                };

                _context.Orders.Add(pedidoActual);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("NumPedido", pedidoActual.Id);
            }
            else
            {
                pedidoActual = await _context.Orders.FindAsync(NumPedido.Value);
            }

            Detalle detalle = new Detalle
            {
                OrderId = pedidoActual.Id,
                ProductId = producto.Id,
                Quantity = 1,
                Price = producto.Price
            };

            _context.Details.Add(detalle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Carrito");
        }
    }
}
