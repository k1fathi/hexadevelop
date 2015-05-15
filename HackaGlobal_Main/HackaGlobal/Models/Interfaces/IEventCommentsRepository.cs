using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface IEventCommentsRepository
    {
        EventComment New();
        bool Add(EventComment entity, bool autoSave = true);
        bool Update(EventComment entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(EventComment entity, bool autoSave = true);
        EventComment Find(int id);
        IQueryable<EventComment> Where(Expression<Func<EventComment, bool>> exp);
        IQueryable<EventComment> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<EventComment, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}