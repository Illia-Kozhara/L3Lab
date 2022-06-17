using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;

namespace L3LabDotNetCore.Services.Notes
{
    public interface INoteService
    {
        IEnumerable<NoteDTO> GetAll();
        NoteDTO GetById(int id);
        int Insert(NoteDTO obj);
        Task<IResult> Update(NoteDTO obj);
        IResult Delete(int id);
    }
}
