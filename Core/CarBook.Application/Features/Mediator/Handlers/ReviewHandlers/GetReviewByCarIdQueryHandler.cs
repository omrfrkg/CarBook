using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;
        public GetReviewByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetReviewsByCarId(request.Id);
            return value.Select(x => new GetReviewByCarIdQueryResult
            {
                CarId = x.CarId,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                ReviewDate = x.ReviewDate,
                ReytingValue = x.ReytingValue,
                ReviewId = x.ReviewId
            }).ToList();
        }
    }
}
