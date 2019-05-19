using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prova1.Models;

namespace Prova1.Controllers
{
    public class AcaosController : Controller
    {
        private readonly Prova1Context _context;

        public AcaosController(Prova1Context context)
        {
            _context = context;
        }

        // GET: Acaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acao.ToListAsync());
        }

        // GET: Acaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao
                .SingleOrDefaultAsync(m => m.ID == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // GET: Acaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Codigo,Atividade")] Acao acao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acao);
        }

        // GET: Acaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao.SingleOrDefaultAsync(m => m.ID == id);
            if (acao == null)
            {
                return NotFound();
            }
            return View(acao);
        }

        // POST: Acaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Codigo,Atividade")] Acao acao)
        {
            if (id != acao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcaoExists(acao.ID))
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
            return View(acao);
        }

        // GET: Acaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao
                .SingleOrDefaultAsync(m => m.ID == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // POST: Acaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acao = await _context.Acao.SingleOrDefaultAsync(m => m.ID == id);
            _context.Acao.Remove(acao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcaoExists(int id)
        {
            return _context.Acao.Any(e => e.ID == id);
        }
    }
}
