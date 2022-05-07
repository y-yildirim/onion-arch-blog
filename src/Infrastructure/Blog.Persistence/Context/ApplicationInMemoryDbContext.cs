using Blog.Domain.Entities;
using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Context
{
    public class ApplicationInMemoryDbContext : DbContext
    {

        public DbSet<Article> Articles => Set<Article>();

        private Faker<Article> _articleFaker;

        public ApplicationInMemoryDbContext(DbContextOptions<ApplicationInMemoryDbContext> options) : base(options)
        {
            Randomizer.Seed = new Random(42);

            _articleFaker = new Faker<Article>(locale: "tr")
                 .RuleFor(i => i.Id, i => i.Random.Uuid())
                 .RuleFor(i => i.UserId, i => i.Random.Uuid())
                 .RuleFor(i => i.CategoryId, i => i.Random.Uuid())
                 .RuleFor(i => i.Title, i => new Lorem().Sentence(3, 7))
                 .RuleFor(i => i.Content, i => new Lorem().Paragraphs(1, 3))
                 .RuleFor(i => i.CreatedAt, i => i.Date.Past(3));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>().HasData(
                _articleFaker.Generate(10)
                );

        }
    }
}
