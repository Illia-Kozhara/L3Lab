using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using System.Web.Http.ModelBinding;

namespace L3LabDotNetCore.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private AppDBContext _dBContext;
        private DbSet<TEntity> _table = null;


        public GenericRepository(AppDBContext dBContext)
        {
            _dBContext = dBContext;
            _table = _dBContext.Set<TEntity>();
        }

        public void Delete(int pk)
        {
            var entity = _table.Find(pk);
            var result = _table.Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            var result = _table.ToList();
            return result;
        }

        public TEntity GetByPk(int pk)
        {
            var result = _table.Find(pk);
            return result;
        }

        public void Insert(TEntity obj)
        {
            var result = _table.Add(obj);
        }

        public void Save()
        {
            _dBContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _table.Attach(obj);
            _dBContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
