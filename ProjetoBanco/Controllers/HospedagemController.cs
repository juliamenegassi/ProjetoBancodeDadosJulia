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
    public class HospedagemController : Controller
    {
        private readonly Contexto _context;

        public HospedagemController(Contexto context)
        {
            _context = context;
        }

        // GET: Hospedagem
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Hospedagem.Include(h => h.Destino).Include(h => h.Hotel);
            return View(await contexto.ToListAsync());
        }

        // GET: Hospedagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hospedagem == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagem
                .Include(h => h.Destino)
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospedagem == null)
            {
                return NotFound();
            }

            return View(hospedagem);
        }

        // GET: Hospedagem/Create
        public IActionResult Create()
        {
            ViewData["DestinoId"] = new SelectList(_context.Destino, "Id", "NomeDestino");
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "NomeHotel");
            return View();
        }

        // POST: Hospedagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiasHospedagem,DataIda,DataVolta,QtdPessoas,DestinoId,HotelId")] Hospedagem hospedagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospedagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoId"] = new SelectList(_context.Destino, "Id", "NomeDestino", hospedagem.DestinoId);
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "NomeHotel", hospedagem.HotelId);
            return View(hospedagem);
        }

        // GET: Hospedagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hospedagem == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagem.FindAsync(id);
            if (hospedagem == null)
            {
                return NotFound();
            }
            ViewData["DestinoId"] = new SelectList(_context.Destino, "Id", "NomeDestino", hospedagem.DestinoId);
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "NomeHotel", hospedagem.HotelId);
            return View(hospedagem);
        }

        // POST: Hospedagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiasHospedagem,DataIda,DataVolta,QtdPessoas,DestinoId,HotelId")] Hospedagem hospedagem)
        {
            if (id != hospedagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospedagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospedagemExists(hospedagem.Id))
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
            ViewData["DestinoId"] = new SelectList(_context.Destino, "Id", "NomeDestino", hospedagem.DestinoId);
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "NomeHotel", hospedagem.HotelId);
            return View(hospedagem);
        }

        // GET: Hospedagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hospedagem == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagem
                .Include(h => h.Destino)
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospedagem == null)
            {
                return NotFound();
            }

            return View(hospedagem);
        }

        // POST: Hospedagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hospedagem == null)
            {
                return Problem("Entity set 'Contexto.Hospedagem'  is null.");
            }
            var hospedagem = await _context.Hospedagem.FindAsync(id);
            if (hospedagem != null)
            {
                _context.Hospedagem.Remove(hospedagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospedagemExists(int id)
        {
          return (_context.Hospedagem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
