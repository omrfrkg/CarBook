using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public DeleteLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
