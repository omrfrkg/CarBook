using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAuthorByBlogIdQueryHandler : IRequestHandler<GetAuthorByBlogIdQuery,GetAuthorByBlogIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetAuthorByBlogIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByBlogIdQueryResult> Handle(GetAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAuthorByBlogId(request.Id);
            return new GetAuthorByBlogIdQueryResult
            {
                AuthorName = value.Author.AuthorName,
                AuthorDescription = value.Author.Description,
                AuthorId = value.AuthorId,
                ImageUrl = value.Author.ImageUrl,
            };
        }
    }

}
