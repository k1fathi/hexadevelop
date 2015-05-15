using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface ITeamsRepository
    {
        Team New();
        bool Add(Team entity, bool autoSave = true);
        bool Update(Team entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(Team entity, bool autoSave = true);
        Team Find(int id);
        IQueryable<Team> Where(Expression<Func<Team, bool>> exp);
        IQueryable<Team> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<Team, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}