using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetAuthorByBlogIdQuery : IRequest<GetAuthorByBlogIdQueryResult>
    {
        public int Id { get; set; }

        public GetAuthorByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
