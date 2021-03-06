﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Repository.Contract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int? id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Remove(T entity);
    }
}
