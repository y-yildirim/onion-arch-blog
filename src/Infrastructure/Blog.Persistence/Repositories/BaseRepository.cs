using Blog.Application.Interfaces.Repository;
using Blog.Domain.Common;
using Blog.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationInMemoryDbContext _dbContext;
        public BaseRepository(ApplicationInMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            var entities = await _dbContext.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }
    }
}
