using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHomeApi.Model;

namespace SmartHomeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorisationcsController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        public AuthorisationcsController(SmartHomeDbContext context)
        {
            _context = context;
        }


        // POST: api/Authorisationcs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostAuthorisationcs(Authorisationcs authorisationcs)
        {
            try
            {
                if (await _context.Users.FirstOrDefaultAsync(p => p.Login == authorisationcs.Login && p.Password == authorisationcs.Password) is User user)
                    return Ok(user);
                else
                    return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
               

    }
}
