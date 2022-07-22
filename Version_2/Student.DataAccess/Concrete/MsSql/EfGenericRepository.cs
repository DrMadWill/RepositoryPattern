using Microsoft.EntityFrameworkCore;
using Student.DataAccess.Abstract;
using Student.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Concrete.MsSql
{
    public class EfGenericRepository<TEntity, TPrimary> : IBaseRepostitory<TEntity, TPrimary> where TEntity : BaseEntity<TPrimary>
    {
        private readonly StudentDbContext _dbContext;
        private DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public EfGenericRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = Table;
            return query;
        }

        public async Task<List<TEntity>> GetAllList()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllListIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await GetAllIncluding(includeProperties).ToListAsync();
        }


        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAll();
            BindIncludeProperties(query, includeProperties);
            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }

        public async ValueTask<TEntity> Find(TPrimary id)
        {
            return await Table.FindAsync(id);   
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        public IQueryable<TEntity> FindByInculding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAll();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.Where(predicate);
        }

        public async Task<TEntity> GetFrist(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }


        public async Task<TEntity> Add(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task<bool> Alll(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.AllAsync(predicate);
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        

        public async Task<int> Count()
        {
            return await Table.CountAsync();
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.CountAsync(predicate);
        }

        private void BindIncludeProperties(IQueryable<TEntity> query,IEnumerable<Expression<Func<TEntity, object>>> includeProperties)
        {
            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

       
        public async Task<TEntity> Update(TEntity entity)
        {
            //Table.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            //Table.Remove(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async Task DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = Table.Where(predicate);
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }

        }
        
        public void Dispose()
        {
            _dbContext?.Dispose();
        }

    }
}
