using ITLA_TV.Core.Application.Interfaces.Repositories;
using ITLA_TV.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITLA_TV.Infraestructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext context;

        public GenericRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = context.Set<TEntity>().AsQueryable();

            foreach (string property in properties) 
            { 
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
