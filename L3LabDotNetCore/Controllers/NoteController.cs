using Microsoft.AspNetCore.Mvc;
using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Cors;
using L3LabDotNetCore.Repositories;
using L3Lab.EntityFrameworkCore.Entities;

namespace L3LabDotNetCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase, INoteController
    {
        private IRepository<Note> _repository;

        public NoteController(IRepository<Note> repository)
        {
            _repository = repository;
        }


        // GET: api/Notes
        [HttpGet]
        [EnableCors("AllowSpecific")]
        public ActionResult GetNotes()
        {
            var result = _repository.GetAll();
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
            var result = _repository.GetById(id);
            return Ok(ToNoteDTO(result));
        }

        // PUT: api/Note/5
        [HttpPut]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PutNote(NoteDTO noteDTO)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(ToNote(noteDTO));
                _repository.Save();
                return Ok();
            }
            else
            {
                return Ok(noteDTO);
            }
        }

        // POST: api/Note
        [HttpPost]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> PostNote(NoteDTO noteDTO)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(ToNote(noteDTO));
                _repository.Save();
                return Ok();
            }
            return Ok();
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        [EnableCors("AllowSpecific")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return Ok();
        }
        private static NoteDTO ToNoteDTO(Note note)
        {
            var noteDTO = NoteMapper.GetInstance.MapToDto(note);
            return noteDTO;
        }
        private static Note ToNote(NoteDTO noteDTO)
        {
            var note = NoteMapper.GetInstance.MapToNote(noteDTO);
            return note;
        }

    }
}
