using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface IEventMembersRepository
    {
        EventMember New();
        bool Add(EventMember entity, bool autoSave = true);
        bool Update(EventMember entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(EventMember entity, bool autoSave = true);
        EventMember Find(int id);
        IQueryable<EventMember> Where(Expression<Func<EventMember, bool>> exp);
        IQueryable<EventMember> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<EventMember, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}