using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using L3LabDotNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Services.Notes
{
    public class NoteService : INoteService
    {
        private IGenericRepository<Note> _repository;
        private readonly IServiceProvider _provider;

        public NoteService(/*IGenericRepository<Note> repository, */IServiceProvider provider)
        {
            _provider = provider;
            //Get DbContext from Service provider without IRepository DI
            var scope = _provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDBContext>();

            _repository = new GenericRepository<Note>(context);
        }
        public NoteService(IGenericRepository<Note> repository)
        {
            _repository = repository;
        }

        public IResult Delete(int id)
        {
            if (_repository.GetByPk(id) == null)
            {
                return Results.BadRequest("Note with same Id dosen`t exist!");
            }

            _repository.Delete(id);
            _repository.Save();
            return Results.Ok();
        }

        public IEnumerable<NoteDTO> GetAll()
        {
            var result = _repository.GetAll();
            if (result.Count == 0)
            {
                return null;
            }

            List<NoteDTO> sub = new List<NoteDTO>();
            foreach (Note i in result)
            {
                sub.Add(ToNoteDTO(i));
            }
            return sub;
        }

        public NoteDTO GetById(int id)
        {
            var result = _repository.GetByPk(id);
            if (result == null)
            {
                return null;
            }

            return ToNoteDTO(result);
        }

        public int Insert(NoteDTO obj)
        {
            if (obj == null)
            {
                return StatusCodes.EmptyData;
            }

            if (_repository.GetByPk(obj.Id) != null)
            {
                return StatusCodes.DataAllredyExist;
            }

            _repository.Insert(ToNote(obj));
            _repository.Save();
            return StatusCodes.OkData;

        }

        public async Task<IResult> Update(NoteDTO obj)
        {
            if (obj == null)
            {
                return Results.NoContent();
            }

            if (_repository.GetByPk(obj.Id) == null)
            {
                return Results.BadRequest("Note with same Id doesen`t exist!");
            }

            _repository.Update(ToNote(obj));
            await _repository.Save();
            return Results.Ok();
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
