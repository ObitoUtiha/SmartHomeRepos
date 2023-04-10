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
    public class HomesController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        public HomesController(SmartHomeDbContext context)
        {
            _context = context;
        }

        // GET: api/Homes
        [HttpGet("HomesOfUser/{Userid}")]
        public async Task<ActionResult<List<Home>>> GetHomesOfUser( int Userid)
        {
            if (Userid != 0)
            {
#pragma warning disable CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
                return await _context.UserInHomes.Where(p => p.UserId == Userid && p.Home != null).Select(p => p.Home ).ToListAsync();
#pragma warning restore CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
            }

            else
            {
                return BadRequest();
            }

        }


        // GET: api/Homes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Home>>> GetHomes()
        {
            return await _context.Homes.ToListAsync();
        }

        // GET: api/Homes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Home>> GetHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);

            if (home == null)
            {
                return NotFound();
            }

            return home;
        }

        // PUT: api/Homes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(int id, Home home)
        {
            if (id != home.HomeId)
            {
                return BadRequest();
            }
            if (home.Name == "" || home.Description == "" || home.FullAddress == "")
                return BadRequest("Some of entry is null");
            _context.Entry(home).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(id))
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

        // POST: api/Homes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Home>> PostHome(Home home)
        {

            Home newHome = new Home
            {
                Name = home.Name,
                Description = home.Description,
                FullAddress = home.FullAddress,
                Owner = home.Owner
            };

            if (newHome.Name == "" || newHome.Description == "" || newHome.FullAddress == "")
                return BadRequest("Some of entry is null");
            _context.Homes.Add(newHome);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HomeExists(newHome.HomeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            UserInHomesController userInHomes = new UserInHomesController(_context);
            UserInHome newUserInHome = new UserInHome
            { 
            HomeId = newHome.HomeId,
            UserId = newHome.Owner
            };

            await userInHomes.PostUserInHome(newUserInHome);

            return CreatedAtAction("GetHome", new { id = newHome.HomeId }, newHome);
        }

        // DELETE: api/Homes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeExists(int id)
        {
            return _context.Homes.Any(e => e.HomeId == id);
        }
    }
}
