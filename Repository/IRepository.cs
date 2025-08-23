namespace WebApplication1.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);
         Task SavesChangesAsync();

    }
}