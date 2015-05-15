using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface INewsRepository
    {
        News New();
        bool Add(News entity, bool autoSave = true);
        bool Update(News entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(News entity, bool autoSave = true);
        News Find(int id);
        IQueryable<News> Where(Expression<Func<News, bool>> exp);
        IQueryable<News> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<News, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}