using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface ITeamUsersRepository
    {
        TeamUser New();
        bool Add(TeamUser entity, bool autoSave = true);
        bool Update(TeamUser entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(TeamUser entity, bool autoSave = true);
        TeamUser Find(int id);
        IQueryable<TeamUser> Where(Expression<Func<TeamUser, bool>> exp);
        IQueryable<TeamUser> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<TeamUser, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}