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
    public class SensorsController : Controller
    {
        private readonly LandslideDbContext _context;

        public SensorsController(LandslideDbContext context)
        {
            _context = context;
        }

        // GET: Sensors
        public async Task<IActionResult> Index()
        {
            var landslideDbContext = _context.Sensors.Include(s => s.Area);
            return View(await landslideDbContext.ToListAsync());
        }

        // GET: Sensors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _context.Sensors
                .Include(s => s.Area)
                .FirstOrDefaultAsync(m => m.SensorId == id);
            if (sensor == null)
            {
                return NotFound();
            }

            return View(sensor);
        }

        // GET: Sensors/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Name");
            return View();
        }

        // POST: Sensors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SensorId,Name,AreaId")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sensor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Name", sensor.AreaId);
            return View(sensor);
        }

        // GET: Sensors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Name", sensor.AreaId);
            return View(sensor);
        }

        // POST: Sensors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SensorId,Name,AreaId")] Sensor sensor)
        {
            if (id != sensor.SensorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SensorExists(sensor.SensorId))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "Name", sensor.AreaId);
            return View(sensor);
        }

        // GET: Sensors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _context.Sensors
                .Include(s => s.Area)
                .FirstOrDefaultAsync(m => m.SensorId == id);
            if (sensor == null)
            {
                return NotFound();
            }

            return View(sensor);
        }

        // POST: Sensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor != null)
            {
                _context.Sensors.Remove(sensor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SensorExists(int id)
        {
            return _context.Sensors.Any(e => e.SensorId == id);
        }
    }
}
