using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Tarea3_JasonTrejos.Data;
using Tarea3_JasonTrejos.Models;

namespace Tarea3_JasonTrejos.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ContextProductos _context;

        public ProductosController(ContextProductos context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index(string buscar)
        {
            var numeroLote = from productos in _context.productos select productos;

            if (!String.IsNullOrEmpty(buscar))
            {
                numeroLote = numeroLote.Where(s => s.lote_Producto!.Contains(buscar));
            }
            ViewData["numeroLote"] = buscar;

            return View(await numeroLote.ToListAsync());
        }

        //public IActionResult Upload()
        //{
        //    ViewData["DeshabilitarBoton"] = true;
        //    return View();
        //}

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.productos == null)
            {
                return NotFound();
            }

            var productos = await _context.productos
                .FirstOrDefaultAsync(m => m.id_Producto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lote_Producto,fechaFabricacion_Producto,nombre_Producto,nombre_Proveedor,fechaCaducidad_Producto")] Productos productos)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.productos == null)
            {
                return NotFound();
            }

            var productos = await _context.productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_Producto,lote_Producto,fechaFabricacion_Producto,nombre_Producto,nombre_Proveedor,fechaCaducidad_Producto")] Productos productos)
        {
            if (id != productos.id_Producto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.id_Producto))
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
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.productos == null)
            {
                return NotFound();
            }

            var productos = await _context.productos
                .FirstOrDefaultAsync(m => m.id_Producto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.productos == null)
            {
                return Problem("Entity set 'ContextProductos.productos'  is null.");
            }
            var productos = await _context.productos.FindAsync(id);
            if (productos != null)
            {
                _context.productos.Remove(productos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
          return (_context.productos?.Any(e => e.id_Producto == id)).GetValueOrDefault();
        }
    }
}
