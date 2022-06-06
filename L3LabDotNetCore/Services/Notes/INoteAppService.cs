using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Services.Notes
{
    public interface INoteAppService : IApplicationService
    {
        public Task<IResult> AddNoteAsync(NoteDTO input);
        public Task<ActionResult<IEnumerable<NoteDTO>>> GetNotesAsync();
        public Task<ActionResult<NoteDTO>> GetNoteByIdAsync(int id);
        public Task<IResult> DeleteNoteAsync(int id);
        public Task<IResult> UpdateNoteAsync(NoteDTO m);
    }
}
