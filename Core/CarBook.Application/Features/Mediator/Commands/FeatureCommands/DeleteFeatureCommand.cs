using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands
{
    public class DeleteFeatureCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteFeatureCommand(int id)
        {
            Id = id;
        }
    }
}
