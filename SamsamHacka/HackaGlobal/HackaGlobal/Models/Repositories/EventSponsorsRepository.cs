using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using HackaGlobal.Models.Interfaces;
using HackaGlobal.Utilities;

namespace HackaGlobal.Models.Repositories
{
    public class EventSponsorsRepository : IDisposable, IEventSponsorsRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<EventSponsor> EventSponsors { get; set; }

        public EventSponsorsRepository(IUnitOfWork db)
        {
            Db = db;
            EventSponsors = Db.Set<EventSponsor>();
        }

        public EventSponsor New()
        {
            return EventSponsors.Create();
        }

        public bool Add(EventSponsor entity, bool autoSave = true)
        {
            try
            {
                EventSponsors.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(EventSponsor entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                EventSponsors.Attach(entity);
                Db.Entry(entity).State = EntityState.Modified;
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id, bool autoSave = true)
        {
            try
            {
                var entity = new EventSponsor().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(EventSponsor entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    EventSponsors.Attach(entity);
                EventSponsors.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public EventSponsor Find(int id)
        {
            try
            {
                return EventSponsors.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<EventSponsor> Where(Expression<Func<EventSponsor, bool>> exp)
        {
            try
            {
                return EventSponsors.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<EventSponsor> Select()
        {
            try
            {
                return EventSponsors;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<EventSponsor, TResult>> selector)
        {
            try
            {
                return EventSponsors.Select(selector);
            }
            catch
            {
                return null;
            }
        }

        public int GetLastIdentity()
        {
            try
            {
                var entity = EventSponsors.OrderByDescending(p => p.Id).FirstOrDefault();
                if (entity != null)
                    return entity.Id;
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public int Save()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Db != null)
                {
                    Db.Dispose();
                    Db = null;
                }
            }
        }
    }
}