using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _repository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Yorum Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            _repository.Delete(id);
            return Ok("Yorum Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Yorum Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _repository.GetById(id);
            return Ok(values);
        }

        [HttpGet("CommentListByBlog/{id}")]
        public IActionResult CommentListByBlog(int id)
        {
            var values = _repository.GetCommentsByBlogId(id);
            return Ok(values);
        }

        [HttpGet("GetCountCommentByBlogId/{id}")]
        public IActionResult GetCountCommentByBlogId(int id)
        {
            var values = _repository.GetCountCommentByBlogId(id);
            return Ok(values);
        }

        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand createCommentCommand)
        {
            await _mediator.Send(createCommentCommand);
            return Ok("Yorum başarıyla eklendi");
        }
    }
}
