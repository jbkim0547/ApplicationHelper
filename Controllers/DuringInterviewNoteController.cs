using ApplicationHelper.Database;
using ApplicationHelper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationHelper.Controllers
{
    [Route("api/duringInterviewNote")]
    [ApiController]
    public class DuringInterviewNoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DuringInterviewNoteController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDuringInterviewNote()
        {
            var duringInterviewNote = await _context.DuringInterview.ToListAsync();

            return Ok(duringInterviewNote);
        }

        [HttpPost]
        public async Task<IActionResult> addDuringInterviewNote(DuringInterviewNote duringInterviewNote)
        {

            _context.DuringInterview.Add(duringInterviewNote);
            await _context.SaveChangesAsync();

            return Ok(duringInterviewNote);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getDuringInterviewNoteById (int id)
        {
            var duringInterviewNote = await _context.DuringInterview.FirstOrDefaultAsync(e => e.Id == id);
            if(duringInterviewNote == null)
            {
                return NotFound();
            }

            return Ok(duringInterviewNote);
        }
    }
}
