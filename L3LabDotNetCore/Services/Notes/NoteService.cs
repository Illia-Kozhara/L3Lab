using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using L3LabDotNetCore.Repositories;

namespace L3LabDotNetCore.Services.Notes
{
    public class NoteService : INoteService
    {
        private IGenericRepository<Note> _repository;

        public NoteService(IGenericRepository<Note> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public IEnumerable<Note> GetAll()
        {
            var result = _repository.GetAll();
            //var sub = result.ForEach(x => ToNoteDTO(x));
            return result;
        }

        public NoteDTO GetById(int id)
        {
            var result = _repository.GetByPk(id);
            return ToNoteDTO(result);
        }

        public void Insert(NoteDTO obj)
        {
            _repository.Insert(ToNote(obj));
            _repository.Save();

        }

        public void Update(NoteDTO obj)
        {
            _repository.Update(ToNote(obj));
            _repository.Save();
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
