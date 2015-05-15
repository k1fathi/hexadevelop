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
    public class TeamUsersRepository : IDisposable, ITeamUsersRepository
    {
        public IUnitOfWork Db { get; set; }
        public IDbSet<TeamUser> TeamUsers { get; set; }

        public TeamUsersRepository(IUnitOfWork db)
        {
            Db = db;
            TeamUsers = Db.Set<TeamUser>();
        }

        public TeamUser New()
        {
            return TeamUsers.Create();
        }

        public bool Add(TeamUser entity, bool autoSave = true)
        {
            try
            {
                TeamUsers.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TeamUser entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Unchanged)
                    return true;
                TeamUsers.Attach(entity);
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
                var entity = new TeamUser().NewDefaultValue();
                entity.Id = id;
                return Delete(entity, autoSave);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TeamUser entity, bool autoSave = true)
        {
            try
            {
                if (Db.Entry(entity).State == EntityState.Detached)
                    TeamUsers.Attach(entity);
                TeamUsers.Remove(entity);
                if (autoSave)
                    return Convert.ToBoolean(Db.SaveChanges());
                return false;
            }
            catch
            {
                return false;
            }
        }

        public TeamUser Find(int id)
        {
            try
            {
                return TeamUsers.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TeamUser> Where(Expression<Func<TeamUser, bool>> exp)
        {
            try
            {
                return TeamUsers.Where(exp);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TeamUser> Select()
        {
            try
            {
                return TeamUsers;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<TeamUser, TResult>> selector)
        {
            try
            {
                return TeamUsers.Select(selector);
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
                var entity = TeamUsers.OrderByDescending(p => p.Id).FirstOrDefault();
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