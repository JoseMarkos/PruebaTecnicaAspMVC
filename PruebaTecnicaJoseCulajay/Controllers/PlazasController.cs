using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaJoseCulajay.Models;
using PruebaTecnicaJoseCulajay.Shared.Infrastructure;

namespace PruebaTecnicaJoseCulajay.Controllers
{
    public class PlazasController : Controller
    {
        private readonly PruebaTecnicaContext _context;

        public PlazasController(PruebaTecnicaContext context)
        {
            _context = context;
        }

        // GET: Plazas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plazas.ToListAsync());
        }

        // GET: Plazas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plaza = await _context.Plazas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plaza == null)
            {
                return NotFound();
            }

            return View(plaza);
        }

        // GET: Plazas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plazas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] Plaza plaza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plaza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plaza);
        }

        // GET: Plazas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plaza = await _context.Plazas.FindAsync(id);
            if (plaza == null)
            {
                return NotFound();
            }
            return View(plaza);
        }

        // POST: Plazas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] Plaza plaza)
        {
            if (id != plaza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plaza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlazaExists(plaza.Id))
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
            return View(plaza);
        }

        // GET: Plazas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plaza = await _context.Plazas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plaza == null)
            {
                return NotFound();
            }

            return View(plaza);
        }

        // POST: Plazas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plaza = await _context.Plazas.FindAsync(id);
            _context.Plazas.Remove(plaza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlazaExists(int id)
        {
            return _context.Plazas.Any(e => e.Id == id);
        }
    }
}
