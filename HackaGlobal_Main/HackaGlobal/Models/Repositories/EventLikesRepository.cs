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
    public class EventLikesRepository : IDisposable, IEventLikesRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<EventLike> EventLikes { get; set; }

        public EventLikesRepository(IUnitOfWork db)
        {
            Db = db;
            EventLikes = Db.Set<EventLike>();
        }

        public EventLike New()
        {
            return EventLikes.Create();
        }

        public bool Add(EventLike entity, bool autoSave = true)
        {
            try
            {
                EventLikes.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(EventLike entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                EventLikes.Attach(entity);
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
                var entity = new EventLike().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(EventLike entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    EventLikes.Attach(entity);
                EventLikes.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public EventLike Find(int id)
        {
            try
            {
                return EventLikes.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<EventLike> Where(Expression<Func<EventLike, bool>> exp)
        {
            try
            {
                return EventLikes.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<EventLike> Select()
        {
            try
            {
                return EventLikes;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<EventLike, TResult>> selector)
        {
            try
            {
                return EventLikes.Select(selector);
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
                var entity = EventLikes.OrderByDescending(p => p.Id).FirstOrDefault();
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