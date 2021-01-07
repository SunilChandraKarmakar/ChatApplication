using ChatApplication.Database;
using ChatApplication.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ChatApplicationDb _db;

        public BaseRepository()
        {
            _db = new ChatApplicationDb();
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int? id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Create(T entity)
        {
            _db.Set<T>().Add(entity);
            bool isCreate = await _db.SaveChangesAsync() > 0;
            
            return entity;
        }                  

        public virtual async Task<T> Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            bool isUpdate = await _db.SaveChangesAsync() > 0;

            return entity;
        }

        public virtual async Task<bool> Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
