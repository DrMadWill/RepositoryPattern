# Repository Pattern (Students Course API) 

## Introduction 
> In this application, we will look at 'repository pattern' implementations. The general application will be as follows.An app that shows the data recorded during the course registration of requirements.This Project uses swagger. 
### Database 
- **Ms SQL**
- **SQLite**
- Desigen
![DbStudent](https://i.stack.imgur.com/bVYB3.png) **Qeyd:** Families Table Added Colum Code. Code unique text. MaxLength 7;
## Version 1 => App : Use Minimal Repository Pattern 
***
## Api Publish Link => [Api Link](https://repopattern.herokuapp.com/)
## Api Publish Link => https://repopattern.herokuapp.com/
![repo](/Version_1/repos.png)

### Overview
> The program uses a simple 'Repository Pattern' structure. In this program,
> - App version
>    - Main App : Using MsSql => [Link](https://github.com/DrMadWill/RepositoryPattern/tree/main/Version_1/RepositoryPattern)
>    - Published App : Using SQLite and Docker => [Link](https://github.com/DrMadWill/RepositoryPattern/tree/main/Version_1/version_publish)

> - Abstract (Interface) Structure
```cs
    public interface IChangeAccess<T>
    {
        Task<T> Create(T Entity);
        Task<T> Update(T Entity);
        Task<T> Delete(T Entity);
    }

    public interface IReadAccess<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
    }

    public interface IBaseRepostitory<T>: IChangeAccess<T>, IReadAccess<T>
    {
        Task Commit();
    }

```
> - Concrete (Class) Structure
```cs

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
```

### Installation
> #### **Install Requirements**
> - Net Core SDK (5.0)
> - SQL Server(2019)
> - SQLite(3)
> - Visual Studio

> Download this Repository after if you select :
> - Main App => Open `RepositoryPattern` folder after Open `RepositoryPattern.sln` after Open `Package Manager Console` after Change `Default project` to `Student.DataAccess` after write console `PM> Add-migration InitalDb` after  `PM> Update-database` 
> - Published App => Open `version_publish` folder after Open `RepositoryPattern.sln`

> after enjoy yourself.

## Version 2 => App : Uses Unit Of Work Pattern, Generic Repostory and Maximal Repository Pattern 
***
> - Test Complated.

> - And Now. Is Writen ............
