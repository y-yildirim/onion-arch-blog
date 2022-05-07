using AutoMapper;
using Blog.Application.Dtos;
using Blog.Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.CQRS.Queries.GetArticleById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleDto>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public GetArticleByIdQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public async Task<ArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetById(request.Id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return articleDto;
        }
    }
}
