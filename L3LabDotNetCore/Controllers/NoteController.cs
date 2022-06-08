using Microsoft.AspNetCore.Mvc;
using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Cors;
using L3LabDotNetCore.Services.Notes;
using L3LabDotNetCore.Repositories;
using L3Lab.EntityFrameworkCore.Entities;

namespace L3LabDotNetCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase, INoteController
    {
        private INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }


        // GET: api/Notes
        [HttpGet]
        [EnableCors("AllowSpecific")]
        public ActionResult GetNotes()
        {
            var result = _noteService.GetAll();
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
            var result = _noteService.GetById(id);
            return Ok(result);
        }

        // PUT: api/Note/5
        [HttpPut]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PutNote(NoteDTO noteDTO)
        {
            _noteService.Update(noteDTO);
            return Ok();
        }

        // POST: api/Note
        [HttpPost]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PostNote(NoteDTO noteDTO)
        {
            _noteService.Insert(noteDTO);
            return Ok();
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            _noteService.Delete(id);
            return Ok();
        }
    }
}
