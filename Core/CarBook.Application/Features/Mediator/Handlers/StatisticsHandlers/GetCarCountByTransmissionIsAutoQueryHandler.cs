using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByTransmissionIsAutoQueryHandler : IRequestHandler<GetCarCountByTransmissionIsAutoQuery, GetCarCountByTransmissionIsAutoQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByTransmissionIsAutoQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public Task<GetCarCountByTransmissionIsAutoQueryResult> Handle(GetCarCountByTransmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByTransmissionIsAuto();
            return Task.FromResult(new GetCarCountByTransmissionIsAutoQueryResult
            {
                CarCountByTransmissionIsAuto = value
            });
        }
    }
}
