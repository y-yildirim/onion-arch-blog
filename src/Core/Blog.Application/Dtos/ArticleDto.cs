namespace Blog.Application.Dtos
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public List<string>? Tags { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
