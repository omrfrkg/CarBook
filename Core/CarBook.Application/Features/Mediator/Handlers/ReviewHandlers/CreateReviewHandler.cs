using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new Review
            {
                CustomerImage = request.CustomerImage,
                CarId = request.CarId,
                Comment = request.Comment,
                CustomerName = request.CustomerName,
                ReytingValue = request.ReytingValue,
                ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
            });
        }
    }
}
