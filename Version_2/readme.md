## Version 2 => App : Uses Unit Of Work Pattern, Generic Repostory, Repository Pattern and N Layer Architecture  
***

### Api Publish Link => [Api Link](https://unirepoapp.herokuapp.com/)
### Api Publish Link => https://unirepoapp.herokuapp.com/
![repo](/Version_2/unirepoapp.herokuapp.com.png)
### Overview
> The program uses 
> - **Unit Of Work Pattern** 
> -  **Repository Pattern** 
> - **Generic Repository (Universal)**
> - **N Layer Architecture**
> - **Lazy Loading**

### Installation
> #### **Install Requirements**
> - Net Core SDK (6.0)
> - SQL Server(2019)
> - SQLite(3)
> - Visual Studio

> Download this Repository after if you select :
> - Main App => Open `Main` folder after Open `Student.Api.sln` after Open `Package Manager Console` after Change `Default project` to `Student.DataAccess` after write console `PM> Add-migration InitalDb` after  `PM> Update-database` 
> - Published App => Open `version_publish` folder after Open `Student.Api.sln`
> after enjoy yourself.

> In this program, **App version**
>  - Main App : Using MsSql => [Link](/Version_2/Main/)
>  - Published App : Using SQLite and Docker => [Link](/Version_2/V_Publish/)
> - Abstract (Interface) Structure(Generic Repository)
```cs
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

        IQueryable<TEntity> FindByInculding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Alll(Expression<Func<TEntity, bool>> predicate);

        Task<int> Count();

        Task<int> Count(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Delete(TEntity entity);

        Task DeleteWhere(Expression<Func<TEntity, bool>> predicate);
    }
```
> - Abstract (IUnitOfWork) 
```cs

    public interface IUnitOfWork
    {
        public IBaseRepostitory<Entity.Student.Student, int> StudentRepository { get; set; }
        public IBaseRepostitory<Family, int> FamilyRepository { get; set; }
        public IBaseRepostitory<Guardian, int> GuardianRepository { get; set; }
        public IBaseRepostitory<GuardianType, int> GuardianTypeRepository { get; set; }
        public IBaseRepostitory<Address, int> AddressRepository { get; set; }

        public Task Commit();
    }

```

> - Concrete (Class) Structure(Generic Reository)
```cs

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

        private void BindIncludeProperties(IQueryable<TEntity> query, IEnumerable<Expression<Func<TEntity, object>>> includeProperties)
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
```

> - Concrete (UnitOfWork)
```cs
    public class UnitOfWork : IUnitOfWork
    {
        // Lazy Loading Repository
        private IBaseRepostitory<Entity.Student.Student, int> _studentRepository;

        public IBaseRepostitory<Entity.Student.Student, int> StudentRepository
        {
            get => RepositoryBuilder<Entity.Student.Student, int>.Builder(_studentRepository, _dbContext);
            set => StudentRepository = value;
        }

        private IBaseRepostitory<Family, int> _familyRepository;

        public IBaseRepostitory<Family, int> FamilyRepository
        {
            get => RepositoryBuilder<Family, int>.Builder(_familyRepository, _dbContext);
            set => FamilyRepository = value;
        }

        private IBaseRepostitory<Guardian, int> _guardianRepository;

        public IBaseRepostitory<Guardian, int> GuardianRepository
        {
            get => RepositoryBuilder<Guardian, int>.Builder(_guardianRepository, _dbContext);
            set => GuardianRepository = value;
        }

        private IBaseRepostitory<GuardianType, int> _guardianTypeRepository;

        public IBaseRepostitory<GuardianType, int> GuardianTypeRepository
        {
            get => RepositoryBuilder<GuardianType, int>.Builder(_guardianTypeRepository, _dbContext);
            set => GuardianTypeRepository = value;
        }

        private IBaseRepostitory<Address, int> _addressRepository;

        public IBaseRepostitory<Address, int> AddressRepository
        {
            get => RepositoryBuilder<Address, int>.Builder(_addressRepository, _dbContext);
            set => AddressRepository = value;
        }

        private readonly StudentDbContext _dbContext;

        public UnitOfWork(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

    public class RepositoryBuilder<TEntity, TPrimary> where TEntity : BaseEntity<TPrimary>
    {
        public static IBaseRepostitory<TEntity, TPrimary> Builder
            (IBaseRepostitory<TEntity, TPrimary> repostitory, StudentDbContext dbContext)
        {
            if (repostitory == null)
            {
                repostitory = new EfGenericRepository<TEntity, TPrimary>(dbContext);
            }
            return repostitory;
        }
    }
```