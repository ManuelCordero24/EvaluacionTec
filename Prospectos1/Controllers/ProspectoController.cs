using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prospectos1.Datos;
using Prospectos1.Models;

namespace Prospectos1.Controllers
{
    public class ProspectoController : Controller
    {
        private readonly contextoBD _context;

        public ProspectoController(contextoBD context)
        {
            _context = context;
        }

        // GET: Prospecto
        public async Task<IActionResult> Index()
        {
              return _context.prospectos != null ? 
                          View(await _context.prospectos.ToListAsync()) :
                          Problem("Entity set 'contextoBD.prospectos'  is null.");
        }

        // GET: Prospecto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.prospectos == null)
            {
                return NotFound();
            }

            var prospecto = await _context.prospectos
                .FirstOrDefaultAsync(m => m.id == id);
            if (prospecto == null)
            {
                return NotFound();
            }

            return View(prospecto);
        }

        // GET: Prospecto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prospecto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nombre,Apellidop,Apellidom,Calle,Numero,Colonia,CodigoP,Telefono,RFC,Estatus")] prospecto prospecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prospecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prospecto);
        }

        // GET: Prospecto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.prospectos == null)
            {
                return NotFound();
            }

            var prospecto = await _context.prospectos.FindAsync(id);
            if (prospecto == null)
            {
                return NotFound();
            }
            return View(prospecto);
        }

        // POST: Prospecto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nombre,Apellidop,Apellidom,Calle,Numero,Colonia,CodigoP,Telefono,RFC,Estatus")] prospecto prospecto)
        {
            if (id != prospecto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prospecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!prospectoExists(prospecto.id))
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
            return View(prospecto);
        }

        // GET: Prospecto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.prospectos == null)
            {
                return NotFound();
            }

            var prospecto = await _context.prospectos
                .FirstOrDefaultAsync(m => m.id == id);
            if (prospecto == null)
            {
                return NotFound();
            }

            return View(prospecto);
        }

        // POST: Prospecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.prospectos == null)
            {
                return Problem("Entity set 'contextoBD.prospectos'  is null.");
            }
            var prospecto = await _context.prospectos.FindAsync(id);
            if (prospecto != null)
            {
                _context.prospectos.Remove(prospecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool prospectoExists(int id)
        {
          return (_context.prospectos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
