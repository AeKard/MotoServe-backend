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
    public class AdminAccountsController : Controller
    {
        private readonly MotoServeContext _context;
    
        public AdminAccountsController(MotoServeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAdminAccounts()
        {
            var adminAccounts = await _context.AdminAccounts
                .Include(a => a.Admin) // join related Admin
                .Select(a => new
                {
                    id = a.Id,
                    email = a.Email,
                    username = a.Admin.Username,
                    firstname = a.Admin.Firstname,
                    lastname = a.Admin.Lastname
                })
                .ToListAsync();

            return Ok(adminAccounts);
        }
        /*
        // GET: AdminAccounts
        public async Task<IActionResult> Index()
        {
            var motoServeContext = _context.AdminAccounts.Include(a => a.Admin);
            return View(await motoServeContext.ToListAsync());
        }

        // GET: AdminAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminAccount = await _context.AdminAccounts
                .Include(a => a.Admin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminAccount == null)
            {
                return NotFound();
            }

            return View(adminAccount);
        }

        // GET: AdminAccounts/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId");
            return View();
        }

        // POST: AdminAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,AdminId")] AdminAccount adminAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", adminAccount.AdminId);
            return View(adminAccount);
        }

        // GET: AdminAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminAccount = await _context.AdminAccounts.FindAsync(id);
            if (adminAccount == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", adminAccount.AdminId);
            return View(adminAccount);
        }

        // POST: AdminAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,AdminId")] AdminAccount adminAccount)
        {
            if (id != adminAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminAccountExists(adminAccount.Id))
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
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", adminAccount.AdminId);
            return View(adminAccount);
        }

        // GET: AdminAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminAccount = await _context.AdminAccounts
                .Include(a => a.Admin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminAccount == null)
            {
                return NotFound();
            }

            return View(adminAccount);
        }

        // POST: AdminAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminAccount = await _context.AdminAccounts.FindAsync(id);
            if (adminAccount != null)
            {
                _context.AdminAccounts.Remove(adminAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminAccountExists(int id)
        {
            return _context.AdminAccounts.Any(e => e.Id == id);
        }
        */
    }
}
