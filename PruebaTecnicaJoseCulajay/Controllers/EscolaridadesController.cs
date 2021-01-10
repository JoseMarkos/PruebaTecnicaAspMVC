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
    public class EscolaridadesController : Controller
    {
        private readonly PruebaTecnicaContext _context;

        public EscolaridadesController(PruebaTecnicaContext context)
        {
            _context = context;
        }

        // GET: Escolaridads
        public async Task<IActionResult> Index()
        {
            return View(await _context.NivelEscolaridad.ToListAsync());
        }

        // GET: Escolaridads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaridad = await _context.NivelEscolaridad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escolaridad == null)
            {
                return NotFound();
            }

            return View(escolaridad);
        }

        // GET: Escolaridads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escolaridads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Escolaridad escolaridad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escolaridad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escolaridad);
        }

        // GET: Escolaridads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaridad = await _context.NivelEscolaridad.FindAsync(id);
            if (escolaridad == null)
            {
                return NotFound();
            }
            return View(escolaridad);
        }

        // POST: Escolaridads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Escolaridad escolaridad)
        {
            if (id != escolaridad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escolaridad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaridadExists(escolaridad.Id))
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
            return View(escolaridad);
        }

        // GET: Escolaridads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaridad = await _context.NivelEscolaridad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escolaridad == null)
            {
                return NotFound();
            }

            return View(escolaridad);
        }

        // POST: Escolaridads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escolaridad = await _context.NivelEscolaridad.FindAsync(id);
            _context.NivelEscolaridad.Remove(escolaridad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolaridadExists(int id)
        {
            return _context.NivelEscolaridad.Any(e => e.Id == id);
        }
    }
}
