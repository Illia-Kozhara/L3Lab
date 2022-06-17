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
        public IActionResult GetNotes()
        {
            var result = _noteService.GetAll();
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        [EnableCors("AllowSpecific")]
        public ActionResult GetNote(int id)
        {
            var result = _noteService.GetById(id);
            if (result == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT: api/Note/5
        [HttpPut]
        [EnableCors("AllowSpecific")]
        public IActionResult PutNote(NoteDTO noteDTO)
        {
            _noteService.Update(noteDTO);
            return Ok(noteDTO);
        }

        // POST: api/Note
        [HttpPost]
        [EnableCors("AllowSpecific")]
        public IActionResult PostNote(NoteDTO noteDTO)
        {
            var result = _noteService.Insert(noteDTO);
            if (result == StatusCodes.EmptyData)
            {
                return NotFound();
            }

            if (result == StatusCodes.DataAllredyExist)
            {
                return BadRequest("Component with same ID already exist");
            }

            return Ok(result);
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        [EnableCors("AllowSpecific")]
        public IActionResult DeleteNote(int id)
        {
            _noteService.Delete(id);
            return Ok();
        }
    }
}
