using ApplicationHelper.Database;
using ApplicationHelper.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationHelper.Controllers
{
    [Route("api/interviewNote")]
    [ApiController]
    public class ApplicationCalendarController : ControllerBase
    { 
        private readonly AppDbContext _context;

        public ApplicationCalendarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviewNote()
        {
            var interviewNote = await _context.Interviews.ToListAsync();
            
            return Ok(interviewNote);
        }


        [HttpPost]
        public async Task<IActionResult> AddCalendar([FromBody] InterviewNote interview) 
        {
            _context.Interviews.Add(interview);
            await _context.SaveChangesAsync();
            return (Ok());
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteInterviewNote(string id)
        {
            var interviewNote = await _context.Interviews.FirstOrDefaultAsync(e => e.id == id);
            if(interviewNote == null)
            {
                return NotFound();
            }


            _context.Interviews.Remove(interviewNote);
            await _context.SaveChangesAsync();

            return (Ok());

        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetInterviewNoteById(string id)
        {
            var interviewNote = await _context.Interviews.FirstOrDefaultAsync(e => e.id == id);
            if(interviewNote == null)
            {
                return NotFound();
            }


            return Ok(interviewNote);

        }

    }
}
