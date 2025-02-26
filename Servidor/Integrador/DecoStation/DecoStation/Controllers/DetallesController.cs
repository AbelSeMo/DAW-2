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
    public class DetallesController : Controller
    {
        private readonly DecoStationContexto _context;

        public DetallesController(DecoStationContexto context)
        {
            _context = context;
        }

        // GET: Detalles
        public async Task<IActionResult> Index()
        {
            var decoStationContexto = _context.Details.Include(d => d.Order);
            return View(await decoStationContexto.ToListAsync());
        }

        // GET: Detalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle = await _context.Details
                .Include(d => d.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalle == null)
            {
                return NotFound();
            }

            return View(detalle);
        }

        // GET: Detalles/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: Detalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,Price,OrderId,ProductId")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", detalle.OrderId);
            return View(detalle);
        }

        // GET: Detalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle = await _context.Details.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", detalle.OrderId);
            return View(detalle);
        }

        // POST: Detalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Price,OrderId,ProductId")] Detalle detalle)
        {
            if (id != detalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleExists(detalle.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", detalle.OrderId);
            return View(detalle);
        }

        // GET: Detalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle = await _context.Details
                .Include(d => d.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalle == null)
            {
                return NotFound();
            }

            return View(detalle);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalle = await _context.Details.FindAsync(id);
            if (detalle != null)
            {
                _context.Details.Remove(detalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleExists(int id)
        {
            return _context.Details.Any(e => e.Id == id);
        }
    }
}
