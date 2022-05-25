using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using AutoMapper;
using L3LabDotNetCore.Models;

namespace L3LabDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NotesContext _context;

        public NoteController(NotesContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet("/notes")]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetNotes()
        {
          if (_context.Notes == null)
          {
                return Problem("Entity set 'MessagesContext.Notes'  is null.");
            }
            return await _context.Notes.Select(x => ToNoteDTO(x))
                .ToListAsync();
        }

        // GET: api/Note/5
        [HttpGet("/note/{id}")]
        public async Task<ActionResult<NoteDTO>> GetNote(int id)
        {
          if (_context.Notes == null)
          {
                return Problem("Entity set 'MessagesContext.Notes'  is null.");
            }
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return ToNoteDTO(note);
        }

        // PUT: api/Note/5
        [HttpPut("/note")]
        public async Task<IActionResult> PutNote( NoteDTO noteDto)
        {
            _context.Entry(ToNote(noteDto)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Problem("DbUpdateConcurrencyException");
            }

            return NoContent();
        }

        // POST: api/Note
        [HttpPost("/note")]
        public async Task<ActionResult<NoteDTO>> PostNote(NoteDTO noteDto)
        {
          if (_context.Notes == null)
          {
              return Problem("Entity set 'MessagesContext.Notes'  is null.");
          }
            _context.Notes.Add(ToNote(noteDto));
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = noteDto.Id }, noteDto);
        }

        // DELETE: api/Note/5
        [HttpDelete("/note/{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            if (_context.Notes == null)
            {
                return Problem("Entity set 'MessagesContext.Notes'  is null.");
            }
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // UPDATE: api/Note/
        // relized at PUT part!!
        /*[HttpPost("Update")]
        public async Task<IActionResult> UpdateNote(Note note)
        {
            if (_context.Notes == null)
            {
                return NotFound();
            }
            var target = await _context.Notes.FindAsync(note.Id);

            if (target == null)
            {
                return NotFound();
            }
            target.Content = note.Content;
            _context.Entry(target).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }*/

        private bool IsNoteExists(int id)
        {
            return (_context.Notes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private Note ToNote(NoteDTO noteDTO)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
                    cfg.CreateMap<NoteDTO, Note>()));
            var note = mapper.Map<Note>(noteDTO);
            return note;
        }
        private static NoteDTO ToNoteDTO(Note note)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
                    cfg.CreateMap<Note, NoteDTO>()));
            var noteDTO = mapper.Map<NoteDTO>(note);
            return noteDTO;
        }
    }
}
