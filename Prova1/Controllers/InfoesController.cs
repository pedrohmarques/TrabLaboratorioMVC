using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prova1.Models;

namespace Prova1.Controllers
{
    public class InfoesController : Controller
    {
        private readonly Prova1Context _context;

        public InfoesController(Prova1Context context)
        {
            _context = context;
        }

        // GET: Infoes
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Infoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info
                .SingleOrDefaultAsync(m => m.ID == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        [HttpPost]
        public ActionResult Index(DateTime? data)
        {
            ViewBag.ordemDeCompra = _context.Compra.Where(m => m.Data == data).ToList();
            ViewBag.ordemDeVenda = _context.Venda.Where(m => m.Data == data).ToList();
            return View();
        }

        // GET: Infoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Infoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Data")] Info info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(info);
        }

        // GET: Infoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info.SingleOrDefaultAsync(m => m.ID == id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        // POST: Infoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Data")] Info info)
        {
            if (id != info.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoExists(info.ID))
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
            return View(info);
        }

        // GET: Infoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info
                .SingleOrDefaultAsync(m => m.ID == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // POST: Infoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var info = await _context.Info.SingleOrDefaultAsync(m => m.ID == id);
            _context.Info.Remove(info);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoExists(int id)
        {
            return _context.Info.Any(e => e.ID == id);
        }
    }
}
