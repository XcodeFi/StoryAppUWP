using RealApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RealApp.Services.Base
{
    public interface ILocalRepo<T> where T : BaseModel, new()
    {
        //Task<List<T>> Get();

        //Task<T> Get(int id);

        //Task<ObservableCollection<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);

        //Task<T> Get(Expression<Func<T, bool>> predicate);

        //AsyncTableQuery<T> AsQueryable();

        //Task<int> Insert(T entity);

        //Task<int> Update(T entity);

        //Task<int> Delete(T entity);

        //Task<int> Count(Expression<Func<T, bool>> predicate = null);

        List<T> Get();

        T Get(int id);

        ObservableCollection<T> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);

        T Get(Expression<Func<T, bool>> predicate);

        TableQuery<T> AsQueryable();

        int Insert(T entity);

       int Update(T entity);

        int Delete(T entity);

       int Count(Expression<Func<T, bool>> predicate = null);
    }
}