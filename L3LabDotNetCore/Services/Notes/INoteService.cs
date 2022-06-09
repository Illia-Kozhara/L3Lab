using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;

namespace L3LabDotNetCore.Services.Notes
{
    public interface INoteService
    {
        IEnumerable<NoteDTO> GetAll();
        NoteDTO GetById(int id);
        void Insert(NoteDTO obj);
        void Update(NoteDTO obj);
        void Delete(int id);
    }
}
