using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using System.Web.Http.ModelBinding;

namespace L3LabDotNetCore.Repositories
{
    public class NoteRepository: IRepository<Note, int>
    {
        private AppDBContext _dBContext;
        
        public NoteRepository(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public bool IsNoteExist(int id) 
        {
            if (_dBContext.Notes.Any(x => x.Id == id) == false) 
            {
                return false;
            }
            return true;

        }

        public IEnumerable<Note> GetAll()
        {
            var result = _dBContext.Notes.ToList();
            return result;
        }

        public Note GetById(int id)
        {
            var result = _dBContext.Notes.Find(id);
            return result;
        }

        public void Insert(Note obj)
        {
            obj.Created = DateTime.Now;
            var result = _dBContext.Notes.Add(obj);
        }

        public void Update(Note obj)
        {
            obj.Created = DateTime.Now;
            _dBContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Note note = _dBContext.Notes.Find(id);
            var result = _dBContext.Notes.Remove(note);
        }

        public void Save()
        {
            _dBContext.SaveChanges();
        }
    }
}
