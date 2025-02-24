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
    [Authorize(Roles = "Administrador")]
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
            // Obtener la lista de categorías ordenadas por nombre
            var categorias = await _context.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();
            ViewData["Categories"] = categorias;

            // Preparar la consulta de productos incluyendo la categoría asociada
            IQueryable<Producto> consulta = _context.Products.Include(p => p.Category);

            // Si no se pasa id, se muestran los productos destacados (Escaparate = true)
            if (id == null)
            {
                consulta = consulta.Where(p => p.Escaparate == true);
            }
            else
            {
                // Si se selecciona una categoría, se filtran los productos por CategoriaID
                consulta = consulta.Where(p => p.CategoriaID == id);
            }

            var productos = await consulta.ToListAsync();
            return View(productos);
        }

        // GET: Escaparate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Escaparate/Create
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Escaparate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Products.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Name", producto.CategoriaID);
            return View(producto);
        }

        // POST: Escaparate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Stock,Escaparate,Imagen,CategoriaID")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Id", producto.CategoriaID);
            return View(producto);
        }

        // GET: Escaparate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Escaparate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            if (producto != null)
            {
                _context.Products.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        // POST: Escaparate/AgregarCarrito/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarCarritoPost(int id)
        {
            // Buscar el producto a agregar
            var producto = await _context.Products.FindAsync(id);
            if (producto == null) return NotFound();

            // Comprobar si existe la variable de sesión "NumPedido"
            var strNumPedido = HttpContext.Session.GetString("NumPedido");
            Pedido pedidoActual = null;

            if (string.IsNullOrEmpty(strNumPedido))
            {
                // Obtener el usuario actual mediante su email (User.Identity.Name)
                string userEmail = User.Identity.Name;
                var usuarioActual = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
                if (usuarioActual == null)
                {
                    return Unauthorized();
                }

                // Carrito vacío: crear un nuevo pedido
                pedidoActual = new Pedido
                {
                    DeliveryTime = DateTime.Now,
                    Confirmed = null,
                    Prepared = null,
                    Delivered = null,
                    Paid = null,
                    Returned = null,
                    Cancelled = null,
                    // Asignar el id del usuario real
                    UserId = usuarioActual.Id,
                    // Estado "Pendiente", por ejemplo, ConditionId = 1
                    ConditionId = 1
                };

                _context.Orders.Add(pedidoActual);
                await _context.SaveChangesAsync();

                // Guardar en sesión el Id del nuevo pedido
                HttpContext.Session.SetString("NumPedido", pedidoActual.Id.ToString());
            }
            else
            {
                int pedidoId = int.Parse(strNumPedido);
                pedidoActual = await _context.Orders.FindAsync(pedidoId);
            }

            // Crear la línea de detalle
            Detalle detalle = new Detalle
            {
                OrderId = pedidoActual.Id,
                ProductId = producto.Id,
                Quantity = 1,
                // Se establece el subtotal igual al precio del producto para una unidad
                Summary = producto.Price
            };

            _context.Details.Add(detalle);
            await _context.SaveChangesAsync();

            // Redirigir al carrito para visualizar el pedido actualizado
            return RedirectToAction("Index", "Carrito");
        }
    }
}
