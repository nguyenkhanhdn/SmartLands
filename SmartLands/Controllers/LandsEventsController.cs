using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartLands.Models;

namespace SmartLands.Controllers
{
    public class LandsEventsController : Controller
    {
        private readonly LandslideDbContext _context;

        public LandsEventsController(LandslideDbContext context)
        {
            _context = context;
        }

        // GET: LandsEvents
        public async Task<IActionResult> Index()
        {
            var landslideDbContext = _context.LandsEvents.Include(l => l.Area);
            return View(await landslideDbContext.ToListAsync());
        }

        // GET: LandsEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landsEvent = await _context.LandsEvents
                .Include(l => l.Area)
                .FirstOrDefaultAsync(m => m.LandsEventId == id);
            if (landsEvent == null)
            {
                return NotFound();
            }

            return View(landsEvent);
        }

        // GET: LandsEvents/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Name");
            return View();
        }

        // POST: LandsEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LandsEventId,AreaId,OccurredAt,Description")] LandsEvent landsEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landsEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Name", landsEvent.AreaId);
            return View(landsEvent);
        }

        // GET: LandsEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landsEvent = await _context.LandsEvents.FindAsync(id);
            if (landsEvent == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Name", landsEvent.AreaId);
            return View(landsEvent);
        }

        // POST: LandsEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LandsEventId,AreaId,OccurredAt,Description")] LandsEvent landsEvent)
        {
            if (id != landsEvent.LandsEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landsEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandsEventExists(landsEvent.LandsEventId))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Name", landsEvent.AreaId);
            return View(landsEvent);
        }

        // GET: LandsEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landsEvent = await _context.LandsEvents
                .Include(l => l.Area)
                .FirstOrDefaultAsync(m => m.LandsEventId == id);
            if (landsEvent == null)
            {
                return NotFound();
            }

            return View(landsEvent);
        }

        // POST: LandsEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landsEvent = await _context.LandsEvents.FindAsync(id);
            if (landsEvent != null)
            {
                _context.LandsEvents.Remove(landsEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandsEventExists(int id)
        {
            return _context.LandsEvents.Any(e => e.LandsEventId == id);
        }
    }
}
