using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Core.Domain;
using Data.Persistence;

namespace VirtualSecretary.Controllers
{
    public class CereriController : Controller
    {
        private readonly CereriDatabaseService _context;

        public CereriController(CereriDatabaseService context)
        {
            _context = context;
        }

        // GET: Cereri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cereri.ToListAsync());
        }

        // GET: Cereri/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cerere = await _context.Cereri
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cerere == null)
            {
                return NotFound();
            }

            return View(cerere);
        }

        // GET: Cereri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cereri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,InitialaTatalui,Email,NumarMatricol,SerieBuletin,NumarBuletin,StareCerere")] Cerere cerere)
        {
            if (ModelState.IsValid)
            {
                cerere.Id = Guid.NewGuid();
                _context.Add(cerere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cerere);
        }

        // GET: Cereri/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cerere = await _context.Cereri.SingleOrDefaultAsync(m => m.Id == id);
            if (cerere == null)
            {
                return NotFound();
            }
            return View(cerere);
        }

        // POST: Cereri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nume,Prenume,InitialaTatalui,Email,NumarMatricol,SerieBuletin,NumarBuletin,StareCerere")] Cerere cerere)
        {
            if (id != cerere.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cerere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CerereExists(cerere.Id))
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
            return View(cerere);
        }

        // GET: Cereri/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cerere = await _context.Cereri
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cerere == null)
            {
                return NotFound();
            }

            return View(cerere);
        }

        // POST: Cereri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cerere = await _context.Cereri.SingleOrDefaultAsync(m => m.Id == id);
            _context.Cereri.Remove(cerere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CerereExists(Guid id)
        {
            return _context.Cereri.Any(e => e.Id == id);
        }
    }
}
