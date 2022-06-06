using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using System.Web.Http.ModelBinding;

namespace L3LabDotNetCore.Repositories
{
    public class NoteRepository: INoteRepository
    {
        private AppDBContext _dBContext;
        
        public NoteRepository(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IResult> AddAsync(string input)
        {   
            var note = new Note(input, DateTime.Now);
            var result = _dBContext.Notes.Add(note);
            var resultStatus = result.State;
            if (resultStatus != EntityState.Added)
            {
                return Results.BadRequest(result);
            }

            await _dBContext.SaveChangesAsync();
            return Results.Ok(note);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var note = await _dBContext.Notes.FindAsync(id);
            if (note == null)
            {
                return Results.NotFound(id);
            }

            var result = _dBContext.Notes.Remove(note);
            var resultStatus = result.State;
            if (resultStatus != EntityState.Deleted)
            {
                return Results.BadRequest(result);
            }

            await _dBContext.SaveChangesAsync();
            return Results.Ok(note);
        }

        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetAsync()
        {   
            var result = await _dBContext.Notes.Select(x => ToNoteDTO(x)).ToListAsync();
            if (result.Count == 0) 
            {
                return null;
            }
            return result;
        }

        public async Task<ActionResult<NoteDTO>> GetByIdAsync(int id)
        {
            var result = await _dBContext.Notes.FindAsync(id);
            if (result == null) 
            {
                return null;
            }
            return ToNoteDTO(result);
        }

        public async Task<IResult> UpdateAsync(NoteDTO m)
        {
            var id = m.Id;
            var note = await _dBContext.Notes.FindAsync(id);
            if (note == null)
            {
                return Results.NotFound(m);
            }

            note.Content = m.Content;
            note.Created = DateTime.Now;
            var result = _dBContext.Notes.Update(note);
            var resultStatus = result.State;
            if (resultStatus != EntityState.Modified)
            {
                return Results.BadRequest(result);
            }

            await _dBContext.SaveChangesAsync();
            return Results.Ok(note);
        }

        public bool IsNoteExist(int id) 
        {
            if (_dBContext.Notes.Any(x => x.Id == id) == false) 
            {
                return false;
            }
            return true;

        }

        private static NoteDTO ToNoteDTO(Note note)
        {
            var noteDTO = NoteMapper.GetInstance.MapToDto(note);
            return noteDTO;
        }
    }
}
