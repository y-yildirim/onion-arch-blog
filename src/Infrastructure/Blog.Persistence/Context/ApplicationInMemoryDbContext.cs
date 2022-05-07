using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Context
{
    public class ApplicationInMemoryDbContext : DbContext
    {
        //private readonly Faker<Article> _articleFaker;

        public DbSet<Article> Articles => Set<Article>();

        public ApplicationInMemoryDbContext(DbContextOptions<ApplicationInMemoryDbContext> options) : base(options)
        {
            //Randomizer.Seed = new Random(42);

            //_articleFaker = new Faker<Article>()
            //    .RuleFor(i => i.Id, i => Guid.NewGuid())
            //    .RuleFor(i => i.UserId, i => Guid.NewGuid())
            //    .RuleFor(i => i.CategoryId, i => Guid.NewGuid())


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var articles = new List<Article>()
            {
                new Article() { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), CategoryId = Guid.NewGuid(), Title = "Web Dev 1", Content = "1 Lorem ipsum dolor sit amet." },
                new Article() { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), CategoryId = Guid.NewGuid(), Title = "Web Dev 2", Content = "2 Lorem ipsum dolor sit amet." }
            };

            var article = new Article() { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), CategoryId = Guid.NewGuid(), Title = "Web Dev 1", Content = "1 Lorem ipsum dolor sit amet." };


            modelBuilder.Entity<Article>().HasData(
                //_articleFaker.Generate(5)
                articles
                );

        }
    }
}
