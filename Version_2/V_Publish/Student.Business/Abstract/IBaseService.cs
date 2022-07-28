namespace Student.Business.Abstract
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetFrist(int id);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Delete(int id);

        Task<bool> IsAlreadyAdded(int id);
    }
}