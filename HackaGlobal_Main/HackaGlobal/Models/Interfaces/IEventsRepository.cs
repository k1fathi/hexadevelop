using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface IEventsRepository
    {
        Event New();
        bool Add(Event entity, bool autoSave = true);
        bool Update(Event entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(Event entity, bool autoSave = true);
        Event Find(int id);
        IQueryable<Event> Where(Expression<Func<Event, bool>> exp);
        IQueryable<Event> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<Event, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}