using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;

namespace L3LabDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class L3LabMessageController : ControllerBase
    {
        private readonly MessagesContext _context;

        public L3LabMessageController(MessagesContext context)
        {
            _context = context;
        }

        // GET: api/L3LabMessage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<L3LabMessage>>> GetL3LabMessages()
        {
          if (_context.L3LabMessages == null)
          {
              return NotFound();
          }
            return await _context.L3LabMessages.ToListAsync();
        }

        // GET: api/L3LabMessage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<L3LabMessage>> GetL3LabMessage(int id)
        {
          if (_context.L3LabMessages == null)
          {
              return NotFound();
          }
            var l3LabMessage = await _context.L3LabMessages.FindAsync(id);

            if (l3LabMessage == null)
            {
                return NotFound();
            }

            return l3LabMessage;
        }

        // PUT: api/L3LabMessage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutL3LabMessage( L3LabMessage l3LabMessage)
        {
            /*if (id != l3LabMessage.Id)
            {
                return BadRequest();
            }*/

            _context.Entry(l3LabMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /*if (!L3LabMessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }*/
            }

            return NoContent();
        }

        // POST: api/L3LabMessage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<L3LabMessage>> PostL3LabMessage(L3LabMessage l3LabMessage)
        {
          if (_context.L3LabMessages == null)
          {
              return Problem("Entity set 'MessagesContext.L3LabMessages'  is null.");
          }
            _context.L3LabMessages.Add(l3LabMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetL3LabMessage", new { id = l3LabMessage.Id }, l3LabMessage);
        }

        // DELETE: api/L3LabMessage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteL3LabMessage(int id)
        {
            if (_context.L3LabMessages == null)
            {
                return NotFound();
            }
            var l3LabMessage = await _context.L3LabMessages.FindAsync(id);
            if (l3LabMessage == null)
            {
                return NotFound();
            }

            _context.L3LabMessages.Remove(l3LabMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool L3LabMessageExists(int id)
        {
            return (_context.L3LabMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
