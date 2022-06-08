using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetByPk(int pk);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(int pk);
        void Save();
    }
}
