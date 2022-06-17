using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Controllers
{
    public interface INoteController
    {
        IActionResult DeleteNote(int id);
        ActionResult GetNote(int id);
        IActionResult GetNotes();
        IActionResult PostNote(NoteDTO noteDTO);
        IActionResult PutNote(NoteDTO noteDTO);
    }
}