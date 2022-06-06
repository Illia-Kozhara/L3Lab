


using L3LabDotNetCore.Models;
using L3LabDotNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Services.Notes
{
    public class NoteAppService : INoteAppService
    {
        private readonly INoteRepository _noteRepository;

        public NoteAppService(INoteRepository repository)
        {
            _noteRepository = repository;
        }

        public async Task<IResult> AddNoteAsync(NoteDTO input)
        {
            var id = input.Id;
            if (input == null) 
            {
                return Results.Problem("Imput data is null.");
            }

            var note = input.Content;
            var result = await _noteRepository.AddAsync(note);
            return Results.Ok(result);
        }

        public async Task<IResult> DeleteNoteAsync(int id)
        {
            if (_noteRepository.IsNoteExist(id) == false)
            {
                return Results.Problem($"Entity with id:{id} not found.");
            }

            var note = await _noteRepository.GetByIdAsync(id);
            if (note == null)
            {
                return Results.NotFound();
            }

            var result = await _noteRepository.DeleteAsync(id);
            return result;
        }

        public async Task<ActionResult<NoteDTO>> GetNoteByIdAsync(int id)
        {
            var result = await _noteRepository.GetByIdAsync(id);
            
            return result;
        }

        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetNotesAsync()
        {
            var result = await _noteRepository.GetAsync();
            return result;
        }

        public async Task<IResult> UpdateNoteAsync(NoteDTO m)
        {
            var id = m.Id;
            if (_noteRepository.IsNoteExist(id) == false)
            {
                return Results.Problem($"Entity with id:{id} not found.");
            }

            var result = await _noteRepository.UpdateAsync(m);
            return result;
        }
    }
}
