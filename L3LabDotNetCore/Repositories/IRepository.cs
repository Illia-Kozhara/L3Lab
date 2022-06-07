using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
        void Save();
    }
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TPrimaryKey pk);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TPrimaryKey pk);
        void Save();
    }

    public interface IEntity<TPrimaryKey>
    {
    }
}
