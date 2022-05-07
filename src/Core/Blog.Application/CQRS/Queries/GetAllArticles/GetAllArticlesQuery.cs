using AutoMapper;
using Blog.Application.Dtos;
using Blog.Application.Interfaces.Repository;
using MediatR;

namespace Blog.Application.CQRS.Queries.GetAllArticles
{
    public class GetAllArticlesQuery : IRequest<List<ArticleDto>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllArticlesQuery, List<ArticleDto>>
        {
            private readonly IArticleRepository _articleRepository;
            private readonly IMapper _mapper;

            public GetAllProductQueryHandler(IArticleRepository articleRepository, IMapper mapper)
            {
                _articleRepository = articleRepository;
                _mapper = mapper;
            }

            public async Task<List<ArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
            {
                var articles = await _articleRepository.GetAll();
                var articleViewModel = _mapper.Map<List<ArticleDto>>(articles);
                return articleViewModel;
            }
        }
    }
}
