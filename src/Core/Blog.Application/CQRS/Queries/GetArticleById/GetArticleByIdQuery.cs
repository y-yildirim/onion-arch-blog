using Blog.Application.Dtos;
using MediatR;

namespace Blog.Application.CQRS.Queries.GetArticleById
{
    public class GetArticleByIdQuery : IRequest<ArticleDto>
    {
        public Guid Id { get; set; }
    }
}
