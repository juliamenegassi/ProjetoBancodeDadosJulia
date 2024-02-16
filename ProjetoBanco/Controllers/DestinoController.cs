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
    public class DestinoController : Controller
    {
        private readonly Contexto _context;

        public DestinoController(Contexto context)
        {
            _context = context;
        }

        // GET: Destino
        public async Task<IActionResult> Index()
        {
              return _context.Destino != null ? 
                          View(await _context.Destino.ToListAsync()) :
                          Problem("Entity set 'Contexto.Destino'  is null.");
        }

        // GET: Destino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Destino == null)
            {
                return NotFound();
            }

            var destino = await _context.Destino
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // GET: Destino/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeDestino")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destino);
        }

        // GET: Destino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Destino == null)
            {
                return NotFound();
            }

            var destino = await _context.Destino.FindAsync(id);
            if (destino == null)
            {
                return NotFound();
            }
            return View(destino);
        }

        // POST: Destino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeDestino")] Destino destino)
        {
            if (id != destino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoExists(destino.Id))
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
            return View(destino);
        }

        // GET: Destino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Destino == null)
            {
                return NotFound();
            }

            var destino = await _context.Destino
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // POST: Destino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Destino == null)
            {
                return Problem("Entity set 'Contexto.Destino'  is null.");
            }
            var destino = await _context.Destino.FindAsync(id);
            if (destino != null)
            {
                _context.Destino.Remove(destino);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoExists(int id)
        {
          return (_context.Destino?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
