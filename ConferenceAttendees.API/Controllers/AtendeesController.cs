using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConferenceAttendees.API.Data;

namespace ConferenceAttendees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AtendeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Atendees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atendee>>> GetAtendees()
        {
            return await _context.Atendees.ToListAsync();
        }

        // GET: api/Atendees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atendee>> GetAtendee(Guid id)
        {
            var atendee = await _context.Atendees.FindAsync(id);

            if (atendee == null)
            {
                return NotFound();
            }

            return atendee;
        }

        // PUT: api/Atendees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtendee(Guid id, Atendee atendee)
        {
            if (id != atendee.Id)
            {
                return BadRequest();
            }

            _context.Entry(atendee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtendeeExists(id))
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

        // POST: api/Atendees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atendee>> PostAtendee(Atendee atendee)
        {
            _context.Atendees.Add(atendee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtendee", new { id = atendee.Id }, atendee);
        }

        // DELETE: api/Atendees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtendee(Guid id)
        {
            var atendee = await _context.Atendees.FindAsync(id);
            if (atendee == null)
            {
                return NotFound();
            }

            _context.Atendees.Remove(atendee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtendeeExists(Guid id)
        {
            return _context.Atendees.Any(e => e.Id == id);
        }
    }
}
