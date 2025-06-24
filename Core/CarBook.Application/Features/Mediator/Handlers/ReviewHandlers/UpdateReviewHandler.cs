using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;
        public UpdateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ReviewId);
            value.CustomerName = request.CustomerName;
            value.CustomerImage = request.CustomerImage;
            value.Comment = request.Comment;
            value.ReytingValue = request.ReytingValue;
            value.CarId = request.CarId;
            value.ReviewDate = request.ReviewDate;
            await _repository.UpdateAsync(value);
        }
    }
}
