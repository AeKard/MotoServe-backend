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
    public class CustomersAccountsController : Controller
    {
        private readonly MotoServeContext _context;

        public CustomersAccountsController(MotoServeContext context)
        {
            _context = context;
        }

        // GET: CustomersAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerAccounts.ToListAsync());
        }

        // GET: CustomersAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccount = await _context.CustomerAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerAccount == null)
            {
                return NotFound();
            }

            return View(customerAccount);
        }

        // GET: CustomersAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomersAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,CustomerId")] CustomerAccount customerAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerAccount);
        }

        // GET: CustomersAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccount = await _context.CustomerAccounts.FindAsync(id);
            if (customerAccount == null)
            {
                return NotFound();
            }
            return View(customerAccount);
        }

        // POST: CustomersAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,CustomerId")] CustomerAccount customerAccount)
        {
            if (id != customerAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerAccountExists(customerAccount.Id))
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
            return View(customerAccount);
        }

        // GET: CustomersAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccount = await _context.CustomerAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerAccount == null)
            {
                return NotFound();
            }

            return View(customerAccount);
        }

        // POST: CustomersAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerAccount = await _context.CustomerAccounts.FindAsync(id);
            if (customerAccount != null)
            {
                _context.CustomerAccounts.Remove(customerAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerAccountExists(int id)
        {
            return _context.CustomerAccounts.Any(e => e.Id == id);
        }
    }
}
