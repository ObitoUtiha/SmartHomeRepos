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
    public class UserInHomesController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        public UserInHomesController(SmartHomeDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInHomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInHome>>> GetUserInHomes()
        {
            return await _context.UserInHomes.ToListAsync();
        }

        // GET: api/UserInHomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInHome>> GetUserInHome(int id)
        {
            var userInHome = await _context.UserInHomes.FindAsync(id);

            if (userInHome == null)
            {
                return NotFound();
            }

            return userInHome;
        }

        // PUT: api/UserInHomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInHome(int id, UserInHome userInHome)
        {
            if (id != userInHome.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInHome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInHomeExists(id))
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

        // POST: api/UserInHomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInHome>> PostUserInHome(UserInHome userInHome)
        {
            UserInHome newUserInHome = new UserInHome
            {
                HomeId = userInHome.HomeId,
                UserId = userInHome.UserId
            };

            _context.UserInHomes.Add(newUserInHome);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserInHomeExists(newUserInHome.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserInHome", new { id = newUserInHome.Id }, newUserInHome);
        }

        // DELETE: api/UserInHomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInHome(int id)
        {
            var userInHome = await _context.UserInHomes.FindAsync(id);
            if (userInHome == null)
            {
                return NotFound();
            }

            _context.UserInHomes.Remove(userInHome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInHomeExists(int id)
        {
            return _context.UserInHomes.Any(e => e.Id == id);
        }
    }
}
