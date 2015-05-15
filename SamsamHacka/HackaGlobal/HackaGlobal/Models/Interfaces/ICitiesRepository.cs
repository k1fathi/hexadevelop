using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface ICitiesRepository
    {
        City New();
        bool Add(City entity, bool autoSave = true);
        bool Update(City entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(City entity, bool autoSave = true);
        City Find(int id);
        IQueryable<City> Where(Expression<Func<City, bool>> exp);
        IQueryable<City> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<City, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}