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

        //Get Information and Join table
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

    }
}
