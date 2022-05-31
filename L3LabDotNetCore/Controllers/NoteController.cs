using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using AutoMapper;
using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Cors;

namespace L3LabDotNetCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase, INoteController
    {
        private readonly L3Lab.EntityFrameworkCore.AppDBContext _context;

        public NoteController(L3Lab.EntityFrameworkCore.AppDBContext context)
        {
            _context = context;
        }


        // GET: api/Notes
        [HttpGet]
        [EnableCors("AllowSpecific")]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetNotes()
        {
            if (_context.Notes.Any() == false)
            {
                return Problem("No entities found!");
            }

            var notes = await _context.Notes.Select(x => ToNoteDTO(x)).ToListAsync();
            return notes;
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        [EnableCors("AllowSpecific")]
        public async Task<ActionResult<NoteDTO>> GetNote(int id)
        {
            if (_context.Notes.Any(x => x.Id == id) == false)
            {
                return Problem($"Entity with id:{id} not found.");
            }

            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            var noteDto = ToNoteDTO(note);
            return noteDto;
        }

        // PUT: api/Note/5
        [HttpPut]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PutNote(NoteDTO noteDTO)
        {
            var id = noteDTO.Id;
            if (_context.Notes.Any(x => x.Id == id) == false)
            {
                return BadRequest();
            }

            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            note.Content = noteDTO.Content;
            var result = _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Note
        [HttpPost]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PostNote(NoteDTO noteDTO)
        {
            var id = noteDTO.Id;
            if (_context.Notes.Any(x => x.Id == id) == true)
            {
                return Problem($"Entity with id:{id} aready exist.");
            }
            var note = new Note(noteDTO.Content, DateTime.Now);
            var result = _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return Ok(note);
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            if (_context.Notes.Any(x => x.Id == id) == false)
            {
                return Problem($"Entity with id:{id} not found.");
            }

            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            var result = _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IsNoteExists(int id)
        {
            return (_context.Notes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //Mapper released method
        //Param note (Note) to NoteDTO object
        private static NoteDTO ToNoteDTO(Note note)
        {
            var noteDTO = NoteMapper.GetInstance.MapToDto(note);
            return noteDTO;
        }
        private Note ToNote(NoteDTO noteDTO)
        {
            var note = NoteMapper.GetInstance.MapToNote(noteDTO);
            return note;
        }
    }
}
