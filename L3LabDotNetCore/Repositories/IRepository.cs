using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Repositories
{
    /*public interface IRepository<Note, int>
    {
        public Task<IResult> AddAsync(string input);
        public Task<ActionResult<IEnumerable<NoteDTO>>> GetAsync();
        public Task<ActionResult<NoteDTO>> GetByIdAsync(int id);
        public Task<IResult> DeleteAsync(int id);
        public Task<IResult> UpdateAsync(NoteDTO m);
        public bool IsNoteExist(int id);
    }*/
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
