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
    public class NewsCommentsRepository : IDisposable, INewsCommentsRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<NewsComment> NewsComments { get; set; }

        public NewsCommentsRepository(IUnitOfWork db)
        {
            Db = db;
            NewsComments = Db.Set<NewsComment>();
        }

        public NewsComment New()
        {
            return NewsComments.Create();
        }

        public bool Add(NewsComment entity, bool autoSave = true)
        {
            try
            {
                NewsComments.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(NewsComment entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                NewsComments.Attach(entity);
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
                var entity = new NewsComment().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(NewsComment entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    NewsComments.Attach(entity);
                NewsComments.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public NewsComment Find(int id)
        {
            try
            {
                return NewsComments.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<NewsComment> Where(Expression<Func<NewsComment, bool>> exp)
        {
            try
            {
                return NewsComments.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<NewsComment> Select()
        {
            try
            {
                return NewsComments;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<NewsComment, TResult>> selector)
        {
            try
            {
                return NewsComments.Select(selector);
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
                var entity = NewsComments.OrderByDescending(p => p.Id).FirstOrDefault();
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