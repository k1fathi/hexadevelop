using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface IEventSponsorsRepository
    {
        EventSponsor New();
        bool Add(EventSponsor entity, bool autoSave = true);
        bool Update(EventSponsor entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(EventSponsor entity, bool autoSave = true);
        EventSponsor Find(int id);
        IQueryable<EventSponsor> Where(Expression<Func<EventSponsor, bool>> exp);
        IQueryable<EventSponsor> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<EventSponsor, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}