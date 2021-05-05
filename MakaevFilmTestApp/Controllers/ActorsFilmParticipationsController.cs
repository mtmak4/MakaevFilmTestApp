using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakaevFilmTestApp.Data;
using MakaevFilmTestApp.Models;

namespace MakaevFilmTestApp.Controllers
{
    public class ActorsFilmParticipationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorsFilmParticipationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActorsFilmParticipations
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActorsFilmParticipation.ToListAsync());
        }

        // GET: ActorsFilmParticipations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorsFilmParticipation = await _context.ActorsFilmParticipation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorsFilmParticipation == null)
            {
                return NotFound();
            }

            return View(actorsFilmParticipation);
        }

        // GET: ActorsFilmParticipations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActorsFilmParticipations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActorId,FilmId")] ActorsFilmParticipation actorsFilmParticipation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actorsFilmParticipation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actorsFilmParticipation);
        }

        // GET: ActorsFilmParticipations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorsFilmParticipation = await _context.ActorsFilmParticipation.FindAsync(id);
            if (actorsFilmParticipation == null)
            {
                return NotFound();
            }
            return View(actorsFilmParticipation);
        }

        // POST: ActorsFilmParticipations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActorId,FilmId")] ActorsFilmParticipation actorsFilmParticipation)
        {
            if (id != actorsFilmParticipation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actorsFilmParticipation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorsFilmParticipationExists(actorsFilmParticipation.Id))
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
            return View(actorsFilmParticipation);
        }

        // GET: ActorsFilmParticipations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorsFilmParticipation = await _context.ActorsFilmParticipation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorsFilmParticipation == null)
            {
                return NotFound();
            }

            return View(actorsFilmParticipation);
        }

        // POST: ActorsFilmParticipations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorsFilmParticipation = await _context.ActorsFilmParticipation.FindAsync(id);
            _context.ActorsFilmParticipation.Remove(actorsFilmParticipation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorsFilmParticipationExists(int id)
        {
            return _context.ActorsFilmParticipation.Any(e => e.Id == id);
        }
    }
}
