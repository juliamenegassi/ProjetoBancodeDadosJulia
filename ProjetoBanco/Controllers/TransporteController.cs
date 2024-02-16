using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBanco.Models;

namespace ProjetoBanco.Controllers
{
    public class TransporteController : Controller
    {
        private readonly Contexto _context;

        public TransporteController(Contexto context)
        {
            _context = context;
        }

        // GET: Transporte
        public async Task<IActionResult> Index()
        {
              return _context.Transporte != null ? 
                          View(await _context.Transporte.ToListAsync()) :
                          Problem("Entity set 'Contexto.Transporte'  is null.");
        }

        // GET: Transporte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transporte == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transporte == null)
            {
                return NotFound();
            }

            return View(transporte);
        }

        // GET: Transporte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transporte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTransporte")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transporte);
        }

        // GET: Transporte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transporte == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transporte.FindAsync(id);
            if (transporte == null)
            {
                return NotFound();
            }
            return View(transporte);
        }

        // POST: Transporte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTransporte")] Transporte transporte)
        {
            if (id != transporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransporteExists(transporte.Id))
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
            return View(transporte);
        }

        // GET: Transporte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transporte == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transporte == null)
            {
                return NotFound();
            }

            return View(transporte);
        }

        // POST: Transporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transporte == null)
            {
                return Problem("Entity set 'Contexto.Transporte'  is null.");
            }
            var transporte = await _context.Transporte.FindAsync(id);
            if (transporte != null)
            {
                _context.Transporte.Remove(transporte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransporteExists(int id)
        {
          return (_context.Transporte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
