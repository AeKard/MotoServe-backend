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
    public class CustomerMotorcycleController : Controller
    {
        private readonly MotoServeContext _context;

        public CustomerMotorcycleController(MotoServeContext context)
        {
            _context = context;
        }
        
    }
}
