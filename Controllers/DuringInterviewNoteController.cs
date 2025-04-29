using ApplicationHelper.Database;
using ApplicationHelper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace ApplicationHelper.Controllers
{
    [Route("api/duringInterviewNote")]
    [ApiController]
    public class DuringInterviewNoteController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly AppDbContext _context;

        public DuringInterviewNoteController(AppDbContext context, IDistributedCache cache)
        {
            _cache = cache;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDuringInterviewNote()
        {
            var cacheKey = "allDuringInterviewNotesList";

            var cachedData = await _cache.GetStringAsync(cacheKey);

            if(!string.IsNullOrEmpty(cachedData))
            {
                Console.WriteLine("Returning data from Redis cache");
                var cachedResult = JsonSerializer.Deserialize<List<DuringInterviewNote>>(cachedData);
                return Ok(cachedResult);
            }

            Console.WriteLine("Cache miss - Fetching from Database");
            var duringInterviewNote = await _context.DuringInterview.ToListAsync();

            var serializedData = JsonSerializer.Serialize(duringInterviewNote);
            await _cache.SetStringAsync(cacheKey, serializedData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

            return Ok(duringInterviewNote);
        }

        [HttpPost]
        public async Task<IActionResult> addDuringInterviewNote(DuringInterviewNote duringInterviewNote)
        {

            _context.DuringInterview.Add(duringInterviewNote);
            await _context.SaveChangesAsync();

            await _cache.RemoveAsync("allDuringInterviewNotesList");

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteInterviewNote (int id)
        {
            var duringInterviewNote = await _context.DuringInterview.FirstOrDefaultAsync(e => e.Id == id);
            if(duringInterviewNote == null)
            {
                return NotFound();
            }

            _context.DuringInterview.Remove(duringInterviewNote);
            await _context.SaveChangesAsync();

            await _cache.RemoveAsync("allDuringInterviewNotesList");

            return NoContent();
        }
    }
}
