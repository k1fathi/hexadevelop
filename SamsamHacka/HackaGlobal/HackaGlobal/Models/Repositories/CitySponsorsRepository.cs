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
    public class CitySponsorsRepository : IDisposable, ICitySponsorsRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<CitySponsor> CitySponsors { get; set; }

        public CitySponsorsRepository(IUnitOfWork db)
        {
            Db = db;
            CitySponsors = Db.Set<CitySponsor>();
        }

        public CitySponsor New()
        {
            return CitySponsors.Create();
        }

        public bool Add(CitySponsor entity, bool autoSave = true)
        {
            try
            {
                CitySponsors.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(CitySponsor entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                CitySponsors.Attach(entity);
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
                var entity = new CitySponsor().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(CitySponsor entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    CitySponsors.Attach(entity);
                CitySponsors.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public CitySponsor Find(int id)
        {
            try
            {
                return CitySponsors.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<CitySponsor> Where(Expression<Func<CitySponsor, bool>> exp)
        {
            try
            {
                return CitySponsors.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<CitySponsor> Select()
        {
            try
            {
                return CitySponsors;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<CitySponsor, TResult>> selector)
        {
            try
            {
                return CitySponsors.Select(selector);
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
                var entity = CitySponsors.OrderByDescending(p => p.Id).FirstOrDefault();
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