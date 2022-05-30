using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Controllers
{
    public interface INoteController
    {
        Task<IActionResult> DeleteNote(int id);
        Task<ActionResult<NoteDTO>> GetNote(int id);
        Task<ActionResult<IEnumerable<NoteDTO>>> GetNotes();
        Task<IActionResult> PostNoteByContent(string text);
        Task<IActionResult> PutNote(NoteDTO noteDTO);
    }
}