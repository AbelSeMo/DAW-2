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
            var decoStationContexto = _context.Products.Include(p => p.Category);
            if (id == null)
            {
                return View(await decoStationContexto.ToListAsync());
            }
            var productoConCategoriaId = await decoStationContexto.Where(p => p.CategoriaID == id).ToListAsync();
            return View(productoConCategoriaId);
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
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Id");
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
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Id", producto.CategoriaID);
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
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Id", producto.CategoriaID);
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
    }
}
