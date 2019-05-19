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
    public class ComprasController : Controller
    {
        private readonly Prova1Context _context;

        public ComprasController(Prova1Context context)
        {
            _context = context;
        }

        // GET: Compras
        public ActionResult Index()
        {
            List<Acao> listAcao = new List<Acao>();
            CompraAcao2 compraAcao = new CompraAcao2();
            compraAcao.compra = _context.Compra.Distinct().ToList();
            foreach(var item in compraAcao.compra)
            {
                listAcao.Add(_context.Acao.First(a => a.ID == item.Acao));
            }
            compraAcao.acao = listAcao;

           return View(compraAcao);
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .SingleOrDefaultAsync(m => m.ID == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewBag.Acoes = _context.Acao.ToList();
            return View();
        }

        public List<SelectListItem> getacoes()
        {
            var result = _context.Acao.ToList();
            List<SelectListItem> acoes = new List<SelectListItem>();
            foreach(var acao in result)
            {
                SelectListItem sellistitem = new SelectListItem() { Value = acao.Codigo, Text = acao.Codigo };
                acoes.Add(sellistitem);
            }

            return acoes;
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Valor,Quantidade,Broker,Data,Acao")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.SingleOrDefaultAsync(m => m.ID == id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Valor,Quantidade,Broker,Data,Acao")] Compra compra)
        {
            if (id != compra.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.ID))
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
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .SingleOrDefaultAsync(m => m.ID == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compra.SingleOrDefaultAsync(m => m.ID == id);
            _context.Compra.Remove(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compra.Any(e => e.ID == id);
        }
    }
}
