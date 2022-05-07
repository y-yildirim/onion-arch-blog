using Blog.Domain.Common;

namespace Blog.Domain.Entities
{
    public class Article : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        //public List<Article>? Articles { get; set; }
    }
}
