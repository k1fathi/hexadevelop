using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface IEventLikesRepository
    {
        EventLike New();
        bool Add(EventLike entity, bool autoSave = true);
        bool Update(EventLike entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(EventLike entity, bool autoSave = true);
        EventLike Find(int id);
        IQueryable<EventLike> Where(Expression<Func<EventLike, bool>> exp);
        IQueryable<EventLike> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<EventLike, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}