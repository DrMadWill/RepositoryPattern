using Microsoft.EntityFrameworkCore;
using Student.DataAccess.Abstract.Communs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepostitory<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public EfBaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Create(TEntity Entity)
        {
            await _context.Set<TEntity>().AddAsync(Entity);
            return Entity;
        }

        public async Task<TEntity> Delete(TEntity Entity)
        {
            _context.Set<TEntity>().Remove(Entity);
            return Entity;
        }

        public async Task<TEntity> Get(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var entity = await _context.Set<TEntity>().ToListAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            return Entity;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

    }
}
