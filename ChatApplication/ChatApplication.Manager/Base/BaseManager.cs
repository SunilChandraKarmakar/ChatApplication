using ChatApplication.Manager.Contract;
using ChatApplication.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Manager.Base
{
    public class BaseManager<T> : IBaseManager<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseManager(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _baseRepository.GetAll();          
        }

        public virtual async Task<T> GetById(int? id)
        {
            return await _baseRepository.GetById(id);
        }

        public virtual async Task<bool> Create(T entity)
        {
            return await _baseRepository.Create(entity);
        }

        public virtual async Task<bool> Update(T entity)
        {
            return await _baseRepository.Update(entity);
        }

        public virtual async Task<bool> Remove(T entity)
        {
            return await _baseRepository.Remove(entity);
        }
    }
}
