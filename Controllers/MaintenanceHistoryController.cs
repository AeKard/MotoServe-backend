using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceHistoryController : Controller
    {
        private readonly MotoServeContext _context;

        public MaintenanceHistoryController(MotoServeContext context)
        {
            _context = context;
        }

        // GET: MaintenanceHistory
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaintenanceHistories.ToListAsync());
        }

        // GET: MaintenanceHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceHistory = await _context.MaintenanceHistories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maintenanceHistory == null)
            {
                return NotFound();
            }

            return View(maintenanceHistory);
        }

        // GET: MaintenanceHistory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MotorcycleId,MechanicId,CustomerId,MaintenanceId,ScheduleId")] MaintenanceHistory maintenanceHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenanceHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maintenanceHistory);
        }

        // GET: MaintenanceHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceHistory = await _context.MaintenanceHistories.FindAsync(id);
            if (maintenanceHistory == null)
            {
                return NotFound();
            }
            return View(maintenanceHistory);
        }

        // POST: MaintenanceHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MotorcycleId,MechanicId,CustomerId,MaintenanceId,ScheduleId")] MaintenanceHistory maintenanceHistory)
        {
            if (id != maintenanceHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenanceHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceHistoryExists(maintenanceHistory.Id))
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
            return View(maintenanceHistory);
        }

        // GET: MaintenanceHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceHistory = await _context.MaintenanceHistories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maintenanceHistory == null)
            {
                return NotFound();
            }

            return View(maintenanceHistory);
        }

        // POST: MaintenanceHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenanceHistory = await _context.MaintenanceHistories.FindAsync(id);
            if (maintenanceHistory != null)
            {
                _context.MaintenanceHistories.Remove(maintenanceHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceHistoryExists(int id)
        {
            return _context.MaintenanceHistories.Any(e => e.Id == id);
        }
    }
}
