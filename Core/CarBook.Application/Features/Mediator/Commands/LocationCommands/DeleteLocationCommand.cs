using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands
{
    public class DeleteLocationCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteLocationCommand(int id)
        {
            Id = id;
        }
    }
}
