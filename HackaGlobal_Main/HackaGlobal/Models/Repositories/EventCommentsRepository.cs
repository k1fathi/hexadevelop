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
    public class EventCommentsRepository : IDisposable, IEventCommentsRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<EventComment> EventComments { get; set; }

        public EventCommentsRepository(IUnitOfWork db)
        {
            Db = db;
            EventComments = Db.Set<EventComment>();
        }

        public EventComment New()
        {
            return EventComments.Create();
        }

        public bool Add(EventComment entity, bool autoSave = true)
        {
            try
            {
                EventComments.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(EventComment entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                EventComments.Attach(entity);
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
                var entity = new EventComment().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(EventComment entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    EventComments.Attach(entity);
                EventComments.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public EventComment Find(int id)
        {
            try
            {
                return EventComments.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<EventComment> Where(Expression<Func<EventComment, bool>> exp)
        {
            try
            {
                return EventComments.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<EventComment> Select()
        {
            try
            {
                return EventComments;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<EventComment, TResult>> selector)
        {
            try
            {
                return EventComments.Select(selector);
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
                var entity = EventComments.OrderByDescending(p => p.Id).FirstOrDefault();
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