using Blog.Application.Interfaces.Repository;
using Blog.Persistence.Context;
using Blog.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationInMemoryDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDB"));
            services.AddTransient<IArticleRepository, ArticleRepository>();


        }
    }
}
