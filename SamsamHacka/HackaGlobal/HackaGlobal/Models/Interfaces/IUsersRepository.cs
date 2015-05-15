using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface IUsersRepository
    {
        User New();
        bool Add(User entity, bool autoSave = true);
        bool Update(User entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(User entity, bool autoSave = true);
        User Find(int id);
        IQueryable<User> Where(Expression<Func<User, bool>> exp);
        IQueryable<User> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<User, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}