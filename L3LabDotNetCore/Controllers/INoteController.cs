using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Controllers
{
    public interface INoteController
    {
        Task<IActionResult> DeleteNote(int id);
        Task<ActionResult<NoteDTO>> GetNote(int id);
        ActionResult GetNotes();
        Task<IActionResult> PostNote(NoteDTO noteDTO);
        Task<IActionResult> PutNote(NoteDTO noteDTO);
    }
}