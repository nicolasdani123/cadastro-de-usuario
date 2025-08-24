using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UsersDbContext _Context;
        private readonly DbSet<T> _dbset;

        public Repository(UsersDbContext context)
        {
            _Context = context;
            _dbset = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }


        public void Update(T entity)
        {
            _dbset.Update(entity);
      }
        public async Task SavesChangesAsync()
        {
            await _Context.SaveChangesAsync();
        }
    }
}