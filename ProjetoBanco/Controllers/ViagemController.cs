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
    public class ViagemController : Controller
    {
        private readonly Contexto _context;

        public ViagemController(Contexto context)
        {
            _context = context;
        }

        // GET: Viagem
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Viagem.Include(v => v.Cliente).Include(v => v.FormaPagamento).Include(v => v.Hospedagem).Include(v => v.Transporte);
            return View(await contexto.ToListAsync());
        }

        // GET: Viagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .Include(v => v.Cliente)
                .Include(v => v.FormaPagamento)
                .Include(v => v.Hospedagem)
                .Include(v => v.Transporte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        public async Task<IActionResult> Imprimir(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .Include(v => v.Cliente)
                .Include(v => v.FormaPagamento)
                .Include(v => v.Hospedagem)
                .Include(v => v.Transporte)
                .FirstOrDefaultAsync(m => m.Id == id);

            viagem.Hospedagem = await _context.Hospedagem
                .Include(c => c.Destino)
                .Include(c => c.Hotel)
                .Where(c => c.Id == viagem.Id).FirstAsync();

            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // GET: Viagem/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente");
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "Id", "NomeFormaPagamento");
            ViewData["HospedagemId"] = new SelectList(_context.Hospedagem, "Id", "DiasHospedagem");
            ViewData["TransporteId"] = new SelectList(_context.Transporte, "Id", "NomeTransporte");
            return View();
        }

        // POST: Viagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,HospedagemId,TransporteId,PrecoViagem,FormaPagamentoId")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", viagem.ClienteId);
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "Id", "NomeFormaPagamento", viagem.FormaPagamentoId);
            ViewData["HospedagemId"] = new SelectList(_context.Hospedagem, "Id", "DiasHospedagem", viagem.HospedagemId);
            ViewData["TransporteId"] = new SelectList(_context.Transporte, "Id", "NomeTransporte", viagem.TransporteId);
            return View(viagem);
        }

        // GET: Viagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", viagem.ClienteId);
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "Id", "NomeFormaPagamento", viagem.FormaPagamentoId);
            ViewData["HospedagemId"] = new SelectList(_context.Hospedagem, "Id", "DiasHospedagem", viagem.HospedagemId);
            ViewData["TransporteId"] = new SelectList(_context.Transporte, "Id", "NomeTransporte", viagem.TransporteId);
            return View(viagem);
        }

        // POST: Viagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,HospedagemId,TransporteId,PrecoViagem,FormaPagamentoId")] Viagem viagem)
        {
            if (id != viagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", viagem.ClienteId);
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormaPagamento, "Id", "NomeFormaPagamento", viagem.FormaPagamentoId);
            ViewData["HospedagemId"] = new SelectList(_context.Hospedagem, "Id", "DiasHospedagem", viagem.HospedagemId);
            ViewData["TransporteId"] = new SelectList(_context.Transporte, "Id", "NomeTransporte", viagem.TransporteId);
            return View(viagem);
        }

        // GET: Viagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .Include(v => v.Cliente)
                .Include(v => v.FormaPagamento)
                .Include(v => v.Hospedagem)
                .Include(v => v.Transporte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // POST: Viagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Viagem == null)
            {
                return Problem("Entity set 'Contexto.Viagem'  is null.");
            }
            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem != null)
            {
                _context.Viagem.Remove(viagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemExists(int id)
        {
          return (_context.Viagem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
