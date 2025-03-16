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
    public class SensorDatasController : Controller
    {
        private readonly LandslideDbContext _context;

        public SensorDatasController(LandslideDbContext context)
        {
            _context = context;
        }

        // GET: SensorDatas
        public async Task<IActionResult> Index()
        {
            var landslideDbContext = _context.SensorDatas.Include(s => s.Sensor);
            return View(await landslideDbContext.ToListAsync());
        }

        // GET: SensorDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorData = await _context.SensorDatas
                .Include(s => s.Sensor)
                .FirstOrDefaultAsync(m => m.SensorDataId == id);
            if (sensorData == null)
            {
                return NotFound();
            }

            return View(sensorData);
        }

        // GET: SensorDatas/Create
        public IActionResult Create()
        {
            ViewData["SensorId"] = new SelectList(_context.Sensors, "SensorId", "Name");
            return View();
        }

        // POST: SensorDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SensorDataId,SensorId,Timestamp,Value,Unit")] SensorData sensorData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sensorData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SensorId"] = new SelectList(_context.Sensors, "SensorId", "Name", sensorData.SensorId);
            return View(sensorData);
        }

        // GET: SensorDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorData = await _context.SensorDatas.FindAsync(id);
            if (sensorData == null)
            {
                return NotFound();
            }
            ViewData["SensorId"] = new SelectList(_context.Sensors, "SensorId", "Name", sensorData.SensorId);
            return View(sensorData);
        }

        // POST: SensorDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SensorDataId,SensorId,Timestamp,Value,Unit")] SensorData sensorData)
        {
            if (id != sensorData.SensorDataId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sensorData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SensorDataExists(sensorData.SensorDataId))
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
            ViewData["SensorId"] = new SelectList(_context.Sensors, "SensorId", "Name", sensorData.SensorId);
            return View(sensorData);
        }

        // GET: SensorDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorData = await _context.SensorDatas
                .Include(s => s.Sensor)
                .FirstOrDefaultAsync(m => m.SensorDataId == id);
            if (sensorData == null)
            {
                return NotFound();
            }

            return View(sensorData);
        }

        // POST: SensorDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sensorData = await _context.SensorDatas.FindAsync(id);
            if (sensorData != null)
            {
                _context.SensorDatas.Remove(sensorData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SensorDataExists(int id)
        {
            return _context.SensorDatas.Any(e => e.SensorDataId == id);
        }
    }
}
