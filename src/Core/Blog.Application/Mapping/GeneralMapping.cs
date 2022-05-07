using AutoMapper;
using Blog.Application.CQRS.Commands.CreateArticle;

namespace Blog.Application.Mapping
{
    // TODO: Implement in CQRS for all DTOs/Views/Commands...
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Article, Dtos.ArticleDto>().ReverseMap();
            CreateMap<Domain.Entities.Article, CreateArticleCommand>().ReverseMap();
        }
    }
}
