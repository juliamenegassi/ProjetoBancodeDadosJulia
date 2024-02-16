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
    public class FormaPagamentoController : Controller
    {
        private readonly Contexto _context;

        public FormaPagamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: FormaPagamento
        public async Task<IActionResult> Index()
        {
              return _context.FormaPagamento != null ? 
                          View(await _context.FormaPagamento.ToListAsync()) :
                          Problem("Entity set 'Contexto.FormaPagamento'  is null.");
        }

        // GET: FormaPagamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormaPagamento == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormaPagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // GET: FormaPagamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormaPagamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFormaPagamento")] FormaPagamento formaPagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaPagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaPagamento);
        }

        // GET: FormaPagamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormaPagamento == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormaPagamento.FindAsync(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }
            return View(formaPagamento);
        }

        // POST: FormaPagamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFormaPagamento")] FormaPagamento formaPagamento)
        {
            if (id != formaPagamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaPagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaPagamentoExists(formaPagamento.Id))
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
            return View(formaPagamento);
        }

        // GET: FormaPagamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormaPagamento == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormaPagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // POST: FormaPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormaPagamento == null)
            {
                return Problem("Entity set 'Contexto.FormaPagamento'  is null.");
            }
            var formaPagamento = await _context.FormaPagamento.FindAsync(id);
            if (formaPagamento != null)
            {
                _context.FormaPagamento.Remove(formaPagamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaPagamentoExists(int id)
        {
          return (_context.FormaPagamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
