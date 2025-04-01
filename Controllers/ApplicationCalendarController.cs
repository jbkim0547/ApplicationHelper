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

    }
}
