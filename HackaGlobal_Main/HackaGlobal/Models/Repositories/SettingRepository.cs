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
    public class SettingRepository : IDisposable, ISettingRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<Setting> Setting { get; set; }

        public SettingRepository(IUnitOfWork db)
        {
            Db = db;
            Setting = Db.Set<Setting>();
        }

        public Setting New()
        {
            return Setting.Create();
        }

        public bool Add(Setting entity, bool autoSave = true)
        {
            try
            {
                Setting.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Setting entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                Setting.Attach(entity);
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
                var entity = new Setting().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Setting entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    Setting.Attach(entity);
                Setting.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Setting Find(int id)
        {
            try
            {
                return Setting.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Setting> Where(Expression<Func<Setting, bool>> exp)
        {
            try
            {
                return Setting.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Setting> Select()
        {
            try
            {
                return Setting;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<Setting, TResult>> selector)
        {
            try
            {
                return Setting.Select(selector);
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
                var entity = Setting.OrderByDescending(p => p.Id).FirstOrDefault();
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