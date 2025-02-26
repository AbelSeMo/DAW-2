using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DecoStation.Data;
using DecoStation.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace DecoStation.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ProductosController : Controller
    {
        private readonly DecoStationContexto _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductosController(DecoStationContexto context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var productos = _context.Products.Include(p => p.Category);
            return View(await productos.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var producto = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Escaparate,Imagen,CategoriaID")] Producto producto)
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

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var producto = await _context.Products.FindAsync(id);
            if (producto == null) return NotFound();
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Name", producto.CategoriaID);
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Escaparate,Imagen,CategoriaID")] Producto producto)
        {
            if (id != producto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var productoImagen = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

                    if (productoImagen == null)
                    {
                        return NotFound();
                    }

                    producto.Imagen = productoImagen.Imagen;

                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
                    {
                        return NotFound();
                    }
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categories, "Id", "Name", producto.CategoriaID);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var producto = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        // POST: Productos/Delete/5
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

        // GET: Productos/CambiarImagen/5 
        public async Task<IActionResult> CambiarImagen(int? id)
        {
            if (id == null || _context.Products == null) return NotFound();
            var producto = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        // POST: Productos/CambiarImagen/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarImagen(int? id, IFormFile imagen)
        {
            if (id == null) return NotFound();
            var producto = await _context.Products.FindAsync(id);
            if (producto == null) return NotFound();
            if (imagen == null) return NotFound();

            if (ModelState.IsValid)
            {
                string rutaImagenes = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                string extension = Path.GetExtension(imagen.FileName);
                string nombreFichero = producto.Id.ToString() + extension;
                string rutaFichero = Path.Combine(rutaImagenes, nombreFichero);
                using (var stream = new FileStream(rutaFichero, FileMode.Create))
                {
                    imagen.CopyTo(stream);
                }
                producto.Imagen = nombreFichero;
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
            }
            return View(producto);
        }
    }

}
