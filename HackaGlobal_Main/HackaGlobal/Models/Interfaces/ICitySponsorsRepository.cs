using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface ICitySponsorsRepository
    {
        CitySponsor New();
        bool Add(CitySponsor entity, bool autoSave = true);
        bool Update(CitySponsor entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(CitySponsor entity, bool autoSave = true);
        CitySponsor Find(int id);
        IQueryable<CitySponsor> Where(Expression<Func<CitySponsor, bool>> exp);
        IQueryable<CitySponsor> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<CitySponsor, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}