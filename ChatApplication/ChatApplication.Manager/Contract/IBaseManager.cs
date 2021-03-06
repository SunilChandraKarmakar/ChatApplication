﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Manager.Contract
{
    public interface IBaseManager<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int? id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Remove(T entity);
    }
}
