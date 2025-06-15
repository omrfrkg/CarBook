using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandByIdQueryHandler
    {
        private readonly ICarRepository _repository;
        public GetCarWithBrandByIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarWithBrandByIdQueryResult> Handle(GetCarWithBrandByIdQuery query)
        {
            var value = await _repository.GetCarWithBrandById(query.id);
            return new GetCarWithBrandByIdQueryResult
            {
                CarId = value.CarId,
                BrandId = value.BrandId,
                BrandName = value.Brand.Name,
                Model = value.Model,
                CoverImageUrl = value.CoverImageUrl,
                Km = value.Km,
                Transmission = value.Transmission,
                BigImageUrl = value.BigImageUrl,
                Seat = value.Seat,
                Luggage = value.Luggage,
                Fuel = value.Fuel
            };
        }
    }
}
