using Blog.Domain.Common;

namespace Blog.Application.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<T> Add(T entity);
    }
}
