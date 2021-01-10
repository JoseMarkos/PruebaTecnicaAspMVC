
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
    public class CandidatosController : Controller
    {
        private readonly PruebaTecnicaContext _context;

        public CandidatosController(PruebaTecnicaContext context)
        {
            _context = context;
        }

        // GET: Candidatoes
        public async Task<IActionResult> Index()
        {
            var pruebaTecnicaContext = _context.Candidatos.Include(c => c.Escolaridad).Include(c => c.Plaza);
            return View(await pruebaTecnicaContext.ToListAsync());
        }

        // GET: Candidatoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos
                .Include(c => c.Escolaridad)
                .Include(c => c.Plaza)
                .FirstOrDefaultAsync(m => m.CUI == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatoes/Create
        public IActionResult Create()
        {
            ViewData["EscolaridadId"] = new SelectList(_context.NivelEscolaridad, "Id", "Id");
            ViewData["PlazaId"] = new SelectList(_context.Plazas, "Id", "Id");
            return View();
        }

        // POST: Candidatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CUI,Nombre,Apellido,Direccion,Telefono,EscolaridadId,PlazaId")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscolaridadId"] = new SelectList(_context.NivelEscolaridad, "Id", "Id", candidato.EscolaridadId);
            ViewData["PlazaId"] = new SelectList(_context.Plazas, "Id", "Id", candidato.PlazaId);
            return View(candidato);
        }

        // GET: Candidatoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            ViewData["EscolaridadId"] = new SelectList(_context.NivelEscolaridad, "Id", "Id", candidato.EscolaridadId);
            ViewData["PlazaId"] = new SelectList(_context.Plazas, "Id", "Id", candidato.PlazaId);
            return View(candidato);
        }

        // POST: Candidatoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CUI,Nombre,Apellido,Direccion,Telefono,EscolaridadId,PlazaId")] Candidato candidato)
        {
            if (id != candidato.CUI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.CUI))
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
            ViewData["EscolaridadId"] = new SelectList(_context.NivelEscolaridad, "Id", "Id", candidato.EscolaridadId);
            ViewData["PlazaId"] = new SelectList(_context.Plazas, "Id", "Id", candidato.PlazaId);
            return View(candidato);
        }

        // GET: Candidatoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos
                .Include(c => c.Escolaridad)
                .Include(c => c.Plaza)
                .FirstOrDefaultAsync(m => m.CUI == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.CUI == id);
        }
    }
}
