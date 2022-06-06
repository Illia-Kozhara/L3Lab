using Microsoft.AspNetCore.Mvc;
using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Cors;
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
            if (result == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        [EnableCors("AllowSpecific")]
        public async Task<ActionResult<NoteDTO>> GetNote(int id)
        {
            var result = await _noteAppService.GetNoteByIdAsync(id);
            if (result == null)
            {
                return BadRequest($"Entity with id:{id} not found.");
            }
            return result;
        }

        // PUT: api/Note/5
        [HttpPut]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PutNote(NoteDTO noteDTO)
        {
            var id = noteDTO.Id;
            if (id == null)
            {
                return NotFound();
            }
            var result = _noteAppService.UpdateNoteAsync(noteDTO);
            if (result == Results.BadRequest())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST: api/Note
        [HttpPost]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PostNote(NoteDTO noteDTO)
        {
            var result = await _noteAppService.AddNoteAsync(noteDTO);
            if (result == Results.BadRequest())
            {
                return BadRequest(result);
            }
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
