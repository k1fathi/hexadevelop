using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface IGalleryRepository
    {
        Gallery New();
        bool Add(Gallery entity, bool autoSave = true);
        bool Update(Gallery entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(Gallery entity, bool autoSave = true);
        Gallery Find(int id);
        IQueryable<Gallery> Where(Expression<Func<Gallery, bool>> exp);
        IQueryable<Gallery> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<Gallery, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}