using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackaGlobal.Models.Interfaces
{
    public interface INewsCommentsRepository
    {
        NewsComment New();
        bool Add(NewsComment entity, bool autoSave = true);
        bool Update(NewsComment entity, bool autoSave = true);
        bool Delete(int id, bool autoSave = true);
        bool Delete(NewsComment entity, bool autoSave = true);
        NewsComment Find(int id);
        IQueryable<NewsComment> Where(Expression<Func<NewsComment, bool>> exp);
        IQueryable<NewsComment> Select();
        IQueryable<TResult> Select<TResult>(Expression<Func<NewsComment, TResult>> selector);
        int GetLastIdentity();
        int Save();
    }
}