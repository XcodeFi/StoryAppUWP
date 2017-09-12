using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealApp.Models;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;

namespace RealApp.Services.Base
{
    public class LocalRepo
    {
        protected static object locker = new object();
        private SQLiteConnection _db;

        public LocalRepo(SQLiteConnection db)
        {
            this._db =db;
        }

        public TableQuery<T> AsQueryable<T>() where T : BaseModel, new()
        {
            lock (locker)
            {
                return _db.Table<T>();
            }
        }

        public  int Count<T>(Expression<Func<T, bool>> predicate = null)  where T : BaseModel, new()
        {

            var query = _db.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return  query.Count();
        }

        public  int Delete<T>(T entity) where T : BaseModel, new()
        {
            return  _db.Delete(entity);
        }

        public  List<T> Get<T>() where T : BaseModel, new()
        {
            return  _db.Table<T>().ToList();
        }

        public  T Get<T>(Expression<Func<T, bool>> predicate) where T : BaseModel, new()
        {
            return _db.Find<T>(predicate);
        }

        public T Get<T>(int id) where T : BaseModel, new()
        {
            return  _db.Find<T>(id);
        }

        //public  ObservableCollection<T> Get<T>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null) where T : BaseModel, new()
        //{
        //    var query = _db.Table<T>();

        //    if (predicate != null)
        //    {
        //        query = query.Where(predicate);
        //    }
        //    if (orderBy != null)
        //    {
        //        query = query.OrderBy<TValue>(orderBy);
        //    }

        //    var collection = new ObservableCollection<T>();
        //    var items =  query.ToList();
        //    foreach (var item in items)
        //    {
        //        collection.Add(item);
        //    }

        //    return collection;
        //}

        public  int Insert<T>(T entity) where T : BaseModel, new()
        {
            return  _db.Insert(entity);
        }

        public  int Update<T>(T entity) where T : BaseModel, new()
        {
            return  _db.Update(entity);
        }
    }
}