using Blog.Application.CQRS.Commands.CreateArticle;
using Blog.Application.CQRS.Queries.GetAllArticles;
using Blog.Application.CQRS.Queries.GetArticleById;
using Blog.Application.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllArticlesQuery();

            return Ok(await _mediator.Send(query));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetArticleByIdQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateArticleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    //var articles = await _articleRepository.GetAll();

        //    Randomizer.Seed = new Random(42);

        //    Faker<Article> articleFaker = new Faker<Article>(locale: "tr")
        //        .RuleFor(i => i.Id, i => i.Random.Uuid())
        //        .RuleFor(i => i.UserId, i => i.Random.Uuid())
        //        .RuleFor(i => i.CategoryId, i => i.Random.Uuid())
        //        .RuleFor(i => i.Title, i => new Lorem(locale: "tr").Sentence(3, 7))
        //        .RuleFor(i => i.Content, i => new Lorem(locale: "tr").Paragraphs(5, 10))
        //        .RuleFor(i => i.CreatedAt, i => i.Date.Past(3));

        //    var articles = articleFaker.Generate(5);

        //    return Ok(articles);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    var article = await _articleRepository.GetById(id);

        //    return Ok(article);
        //}
    }
}
