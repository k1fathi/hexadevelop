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
    public class UsersRepository : IDisposable, IUsersRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<User> Users { get; set; }

        public UsersRepository(IUnitOfWork db)
        {
            Db = db;
            Users = Db.Set<User>();
        }

        public User New()
        {
            return Users.Create();
        }

        public User Exist(string email, string password)
        {
            try
            {
                return Users.SingleOrDefault(p => p.Email == email && p.Password == password);
            }
            catch
            {
                return null;
            }
        }

        public bool Add(User entity, bool autoSave = true)
        {
            try
            {
                Users.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(User entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                Users.Attach(entity);
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
                var entity = new User().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(User entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    Users.Attach(entity);
                Users.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public User Find(int id)
        {
            try
            {
                return Users.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<User> Where(Expression<Func<User, bool>> exp)
        {
            try
            {
                return Users.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<User> Select()
        {
            try
            {
                return Users;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<User, TResult>> selector)
        {
            try
            {
                return Users.Select(selector);
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
                var entity = Users.OrderByDescending(p => p.Id).FirstOrDefault();
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