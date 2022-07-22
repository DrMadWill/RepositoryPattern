using Student.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Abstract
{
    public interface IBaseRepostitory<TEntity, in TPrimary> : IDisposable
        where TEntity : BaseEntity<TPrimary>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetAllList();
        Task<List<TEntity>> GetAllListIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        ValueTask<TEntity> Find(TPrimary id);
        Task<TEntity> GetFrist(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindByInculding(Expression<Func<TEntity, bool>> predicate,params Expression<Func<TEntity, object>>[] includeProperties);
        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Alll(Expression<Func<TEntity, bool>> predicate);

        Task<int> Count();
        Task<int> Count(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        Task DeleteWhere(Expression<Func<TEntity, bool>> predicate);
        
    }
}
