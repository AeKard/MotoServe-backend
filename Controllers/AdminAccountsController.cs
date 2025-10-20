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
    public class CreateAdminAccountDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }

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

        [HttpPost("create-admin-account")]
        public async Task<IActionResult> CreateAdminAccount([FromBody] CreateAdminAccountDto dto)
        {
            try
            {


                if (dto == null)
                    return BadRequest("Invalid data.");

                // Create the new AdminAccount with a linked Admin
                var account = new AdminAccount
                {
                    Email = dto.Email,
                    Password = dto.Password,
                    Admin = new Admin
                    {
                        Username = dto.Username,
                        Firstname = dto.Firstname,
                        Lastname = dto.Lastname
                    }
                };

                // Add and save both entities in one go
                _context.AdminAccounts.Add(account);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Admin account created successfully",
                    adminAccount = new
                    {
                        id = account.Id,
                        email = account.Email,
                        username = account.Admin.Username,
                        firstname = account.Admin.Firstname,
                        lastname = account.Admin.Lastname
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
