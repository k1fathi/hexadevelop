using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface ICityOrganizersRepository
    {
        CityOrganizer New();
        bool Add(CityOrganizer entity, bool autoSave = true);
        bool Update(CityOrganizer entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(CityOrganizer entity, bool autoSave = true);
        CityOrganizer Find(int id);
        IQueryable<CityOrganizer> Where(Expression<Func<CityOrganizer, bool>> exp);
        IQueryable<CityOrganizer> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<CityOrganizer, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}