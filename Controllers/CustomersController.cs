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
    public class CustomersController : Controller
    {
        private readonly MotoServeContext _context;

        public CustomersController(MotoServeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAccounts()
        {
            var customerAccounts = await _context.CustomerAccounts
                .Include(a => a.Customer) // join related Customer
                .Select(a => new
                {
                    id = a.Id,
                    email = a.Email,
                    username = a.Customer.Username,
                    firstname = a.Customer.Firstname,
                    lastname = a.Customer.Lastname
                })
                .ToListAsync();

            return Ok(customerAccounts);
        }
    }
}
