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
    public class CityOrganizersRepository : IDisposable, ICityOrganizersRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<CityOrganizer> CityOrganizerOrganizers { get; set; }

        public CityOrganizersRepository(IUnitOfWork db)
        {
            Db = db;
            CityOrganizerOrganizers = Db.Set<CityOrganizer>();
        }

        public CityOrganizer New()
        {
            return CityOrganizerOrganizers.Create();
        }

        public bool Add(CityOrganizer entity, bool autoSave = true)
        {
            try
            {
                CityOrganizerOrganizers.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(CityOrganizer entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                CityOrganizerOrganizers.Attach(entity);
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
                var entity = new CityOrganizer().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(CityOrganizer entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    CityOrganizerOrganizers.Attach(entity);
                CityOrganizerOrganizers.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public CityOrganizer Find(int id)
        {
            try
            {
                return CityOrganizerOrganizers.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<CityOrganizer> Where(Expression<Func<CityOrganizer, bool>> exp)
        {
            try
            {
                return CityOrganizerOrganizers.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<CityOrganizer> Select()
        {
            try
            {
                return CityOrganizerOrganizers;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<CityOrganizer, TResult>> selector)
        {
            try
            {
                return CityOrganizerOrganizers.Select(selector);
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
                var entity = CityOrganizerOrganizers.OrderByDescending(p => p.Id).FirstOrDefault();
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