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
    public class AdminsController : Controller
    {
        private readonly MotoServeContext _context;

        public AdminsController(MotoServeContext context)
        {
            _context = context;
        }
        // Get all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var admins = await _context.Admins
                .Include(a => a.AdminAccounts)
                .ToListAsync();

            return Ok(admins);
        }
        // Get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var admin = await _context.Admins
                .Include(a => a.AdminAccounts)
                .FirstOrDefaultAsync(a => a.AdminId == id);

            if (admin == null)
                return NotFound();

            return Ok(admin);
        }
        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            var admins = await _context.Admins.ToListAsync();
            return Ok(admins);
        }

    }
}
