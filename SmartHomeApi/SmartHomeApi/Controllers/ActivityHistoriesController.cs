using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHomeApi.Model;

namespace SmartHomeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityHistoriesController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        public ActivityHistoriesController(SmartHomeDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivityHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityHistory>>> GetActivityHistories()
        {
            return await _context.ActivityHistories.ToListAsync();
        }

        // GET: api/ActivityHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityHistory>> GetActivityHistory(int id)
        {
            var activityHistory = await _context.ActivityHistories.FindAsync(id);

            if (activityHistory == null)
            {
                return NotFound();
            }

            return activityHistory;
        }

        // PUT: api/ActivityHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityHistory(int id, ActivityHistory activityHistory)
        {
            if (id != activityHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(activityHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityHistoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActivityHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityHistory>> PostActivityHistory(ActivityHistory activityHistory)
        {
            _context.ActivityHistories.Add(activityHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActivityHistoryExists(activityHistory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActivityHistory", new { id = activityHistory.Id }, activityHistory);
        }

        // DELETE: api/ActivityHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityHistory(int id)
        {
            var activityHistory = await _context.ActivityHistories.FindAsync(id);
            if (activityHistory == null)
            {
                return NotFound();
            }

            _context.ActivityHistories.Remove(activityHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityHistoryExists(int id)
        {
            return _context.ActivityHistories.Any(e => e.Id == id);
        }
    }
}
