using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface ISettingRepository
    {
        Setting New();
        bool Add(Setting entity, bool autoSave = true);
        bool Update(Setting entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(Setting entity, bool autoSave = true);
        Setting Find(int id);
        IQueryable<Setting> Where(Expression<Func<Setting, bool>> exp);
        IQueryable<Setting> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<Setting, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}