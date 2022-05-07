using Blog.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.CQRS.Queries.GetArticleById
{
    public class GetArticleByIdQuery : IRequest<ArticleDto>
    {
        public Guid Id { get; set; }
    }
}
