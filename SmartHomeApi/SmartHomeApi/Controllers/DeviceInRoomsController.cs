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
    public class DeviceInRoomsController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        public DeviceInRoomsController(SmartHomeDbContext context)
        {
            _context = context;
        }

        // GET: api/DeviceInRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceInRoom>>> GetDeviceInRooms()
        {
            return await _context.DeviceInRooms.ToListAsync();
        }

        // GET: api/DeviceInRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceInRoom>> GetDeviceInRoom(int id)
        {
            var deviceInRoom = await _context.DeviceInRooms.FindAsync(id);

            if (deviceInRoom == null)
            {
                return NotFound();
            }

            return deviceInRoom;
        }

        // PUT: api/DeviceInRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceInRoom(int id, DeviceInRoom deviceInRoom)
        {
            if (id != deviceInRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(deviceInRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceInRoomExists(id))
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

        // POST: api/DeviceInRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeviceInRoom>> PostDeviceInRoom(DeviceInRoom deviceInRoom)
        {
            _context.DeviceInRooms.Add(deviceInRoom);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeviceInRoomExists(deviceInRoom.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeviceInRoom", new { id = deviceInRoom.Id }, deviceInRoom);
        }

        // DELETE: api/DeviceInRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceInRoom(int id)
        {
            var deviceInRoom = await _context.DeviceInRooms.FindAsync(id);
            if (deviceInRoom == null)
            {
                return NotFound();
            }

            _context.DeviceInRooms.Remove(deviceInRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceInRoomExists(int id)
        {
            return _context.DeviceInRooms.Any(e => e.Id == id);
        }
    }
}
