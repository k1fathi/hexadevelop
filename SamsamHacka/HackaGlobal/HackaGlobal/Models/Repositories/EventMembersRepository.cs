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
    public class EventMembersRepository : IDisposable, IEventMembersRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<EventMember> EventMembers { get; set; }

        public EventMembersRepository(IUnitOfWork db)
        {
            Db = db;
            EventMembers = Db.Set<EventMember>();
        }

        public EventMember New()
        {
            return EventMembers.Create();
        }

        public bool Add(EventMember entity, bool autoSave = true)
        {
            try
            {
                EventMembers.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(EventMember entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                EventMembers.Attach(entity);
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
                var entity = new EventMember().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(EventMember entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    EventMembers.Attach(entity);
                EventMembers.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public EventMember Find(int id)
        {
            try
            {
                return EventMembers.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<EventMember> Where(Expression<Func<EventMember, bool>> exp)
        {
            try
            {
                return EventMembers.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<EventMember> Select()
        {
            try
            {
                return EventMembers;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<EventMember, TResult>> selector)
        {
            try
            {
                return EventMembers.Select(selector);
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
                var entity = EventMembers.OrderByDescending(p => p.Id).FirstOrDefault();
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