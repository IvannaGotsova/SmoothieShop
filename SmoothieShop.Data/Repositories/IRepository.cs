﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Repositories
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class;
        IQueryable<T> AllReadonly<T>() where T : class;
        IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class;
        Task<T> GetByIdAsync<T>(object id) where T : class;
        Task<T> GetByIdsAsync<T>(object[] id) where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;
        void Update<T>(T entity) where T : class;
        Task UpdateAsync<T>(object id) where T : class;
        void UpdateRange<T>(IEnumerable<T> entities) where T : class;
        Task DeleteAsync<T>(object id) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(IEnumerable<T> entities) where T : class;
        void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class;
        void Detach<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}
