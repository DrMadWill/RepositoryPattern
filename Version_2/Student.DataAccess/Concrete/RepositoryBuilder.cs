using Student.DataAccess.Abstract;
using Student.DataAccess.Concrete.MsSql;
using Student.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Concrete
{
    public class RepositoryBuilder<TEntity,TPrimary> where TEntity : BaseEntity<TPrimary>
    {
        public static IBaseRepostitory<TEntity,TPrimary> Builder
            (IBaseRepostitory<TEntity, TPrimary> repostitory, StudentDbContext dbContext)
        {
            if(repostitory == null)
            {
                repostitory = new EfGenericRepository<TEntity, TPrimary>(dbContext);
            }
            return repostitory;
        }
    }
}
