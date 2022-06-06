using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Controllers
{
    public interface INoteController
    {
        Task<IResult> DeleteNote(int id);
        Task<ActionResult<NoteDTO>> GetNote(int id);
        Task<ActionResult<IEnumerable<NoteDTO>>> GetNotes();
        Task<IActionResult> PostNote(NoteDTO noteDTO);
        Task<IActionResult> PutNote(NoteDTO noteDTO);
    }
}