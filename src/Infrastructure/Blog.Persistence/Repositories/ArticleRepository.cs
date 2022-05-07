using Blog.Application.Interfaces.Repository;
using Blog.Domain.Entities;
using Blog.Persistence.Context;

namespace Blog.Persistence.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationInMemoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
