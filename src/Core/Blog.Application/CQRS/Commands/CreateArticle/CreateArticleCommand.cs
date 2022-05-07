using AutoMapper;
using Blog.Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.CQRS.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
        {
            IArticleRepository _articleRepository;
            private IMapper _mapper;

            public CreateArticleCommandHandler(IArticleRepository articleRepository, IMapper mapper)
            {
                _articleRepository = articleRepository;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
            {
                var article = _mapper.Map<Domain.Entities.Article>(request);
                await _articleRepository.Add(article);
                return article.Id;
            }
        }
    }
}
