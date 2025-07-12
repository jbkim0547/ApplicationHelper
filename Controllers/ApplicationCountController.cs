using ApplicationHelper.Database;
using ApplicationHelper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ApplicationHelper.Controllerss
{
    [Route("api/applicationCount")]
    [ApiController]
    public class ApplicationCountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApplicationCountController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetApplicationCount ()
        {
            var applicationCount = await _context.ApplicationCount.ToListAsync();

            return Ok(applicationCount);
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicationCount([FromBody] ApplicationCount applicationCount)
        {
            _context.ApplicationCount.Add(applicationCount);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
