namespace ITLA_TV.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);

        Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties);
    }
}
