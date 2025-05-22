using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);
            value.AuthorId = request.AuthorId;
            value.CreatedDate = request.CreatedDate;
            value.CategoryId = request.CategoryId;
            value.Title = request.Title;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Description = request.Description;
            await _repository.UpdateAsync(value);
        }
    }
}
