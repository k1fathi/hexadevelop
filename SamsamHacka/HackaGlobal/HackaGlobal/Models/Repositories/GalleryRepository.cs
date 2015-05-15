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
    public class GalleryRepository : IDisposable, IGalleryRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<Gallery> Gallery { get; set; }

        public GalleryRepository(IUnitOfWork db)
        {
            Db = db;
            Gallery = Db.Set<Gallery>();
        }

        public Gallery New()
        {
            return Gallery.Create();
        }

        public bool Add(Gallery entity, bool autoSave = true)
        {
            try
            {
                Gallery.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Gallery entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                Gallery.Attach(entity);
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
                var entity = new Gallery().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Gallery entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    Gallery.Attach(entity);
                Gallery.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Gallery Find(int id)
        {
            try
            {
                return Gallery.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Gallery> Where(Expression<Func<Gallery, bool>> exp)
        {
            try
            {
                return Gallery.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Gallery> Select()
        {
            try
            {
                return Gallery;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<Gallery, TResult>> selector)
        {
            try
            {
                return Gallery.Select(selector);
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
                var entity = Gallery.OrderByDescending(p => p.Id).FirstOrDefault();
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