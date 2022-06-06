using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using AutoMapper;
using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Cors;
using L3LabDotNetCore.Repositories;
using L3LabDotNetCore.Services.Notes;

namespace L3LabDotNetCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase, INoteController
    {
        private INoteAppService _noteAppService;

        public NoteController(INoteAppService noteAppService)
        {
            _noteAppService = noteAppService;
        }


        // GET: api/Notes
        [HttpGet]
        [EnableCors("AllowSpecific")]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetNotes()
        {
            var result = await _noteAppService.GetNotesAsync();
            return result;
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        [EnableCors("AllowSpecific")]
        public async Task<ActionResult<NoteDTO>> GetNote(int id)
        {
            var result = await _noteAppService.GetNoteByIdAsync(id);
            return result;
        }

        // PUT: api/Note/5
        [HttpPut]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PutNote(NoteDTO noteDTO)
        {
            var note = await _noteAppService.UpdateNoteAsync(noteDTO);
            return NoContent();
        }

        // POST: api/Note
        [HttpPost]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PostNote(NoteDTO noteDTO)
        {
            var result = await _noteAppService.AddNoteAsync(noteDTO);
            return Ok(result);
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        [EnableCors("AllowSpecific")]
        public async Task<IResult> DeleteNote(int id)
        {
            var result = _noteAppService.DeleteNoteAsync(id);
            return await result;
        }
    }
}
