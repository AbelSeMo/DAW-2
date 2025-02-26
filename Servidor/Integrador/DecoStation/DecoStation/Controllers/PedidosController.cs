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
    public class PedidosController : Controller
    {
        private readonly DecoStationContexto _context;

        public PedidosController(DecoStationContexto context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var decoStationContexto = _context.Orders.Include(p => p.Condition).Include(p => p.User);
            return View(await decoStationContexto.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Orders
                .Include(p => p.Condition)
                .Include(p => p.User)
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Description");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "CodigoPostal");
            return View();
        }

        // POST: Pedidos/Create
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

        // GET: Pedidos/Edit/5
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

        // POST: Pedidos/Edit/5
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
                    var pedidosExistentes = await _context.Orders.FindAsync(id);

                    if (pedidosExistentes == null)
                    {
                        return NotFound();
                    }

                    pedidosExistentes.ConditionId = pedido.ConditionId;
                    pedidosExistentes.Confirmed = (pedido.ConditionId == 1) ? DateTime.Now : pedidosExistentes.Confirmed;
                    pedidosExistentes.Prepared = (pedido.ConditionId == 2) ? DateTime.Now : pedidosExistentes.Prepared;
                    pedidosExistentes.Delivered = (pedido.ConditionId == 3) ? DateTime.Now : pedidosExistentes.Delivered;
                    pedidosExistentes.Paid = (pedido.ConditionId == 4) ? DateTime.Now : pedidosExistentes.Paid;
                    pedidosExistentes.Returned = (pedido.ConditionId == 5) ? DateTime.Now : pedidosExistentes.Returned;
                    pedidosExistentes.Cancelled = (pedido.ConditionId == 6) ? DateTime.Now : pedidosExistentes.Cancelled;

                    _context.Update(pedidosExistentes);
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
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
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

        // POST: Pedidos/Delete/5
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
        // GET: Pedidos/AvanzarEstado/5
        public async Task<IActionResult> SiguienteEstado(int id)
        {
            // Buscar el pedido por ID
            var pedido = await _context.Orders
                .Include(p => p.Condition)
                .FirstOrDefaultAsync(p => p.Id == id);

            // Verificar si el pedido existe
            if (pedido == null)
            {
                return NotFound();
            }

            // Verificar que el pedido no esté en el último estado posible (Entregado)
            if (pedido.ConditionId > 3)
            {
                return BadRequest("El pedido ya está en el estado final.");
            }

            // Obtener el siguiente estado
            var siguienteEstado = _context.Conditions
                .FirstOrDefault(e => e.Id == pedido.ConditionId + 1);

            if (siguienteEstado == null)
            {
                return NotFound("El siguiente estado no existe.");
            }

            // Actualizar el estado del pedido
            pedido.ConditionId = siguienteEstado.Id;

            // Asignar la fecha correspondiente al nuevo estado
            switch (siguienteEstado.Description)
            {
                case "Confirmado":
                    pedido.Confirmed = DateTime.Now;
                    break;
                case "Preparado":
                    pedido.Prepared = DateTime.Now;
                    break;
                case "Enviado":
                    pedido.Delivered = DateTime.Now;
                    break;
                case "Cobrado":
                    pedido.Paid = DateTime.Now;
                    break;
                default:
                    break;
            }

            // Guardar los cambios en la base de datos
            _context.Update(pedido);
            await _context.SaveChangesAsync();

            // Redirigir al usuario a la página de detalles del pedido
            return RedirectToAction("Index");
        }

    }
}
