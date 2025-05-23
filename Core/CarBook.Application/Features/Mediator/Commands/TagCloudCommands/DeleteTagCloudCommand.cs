using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class DeleteTagCloudCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteTagCloudCommand(int id)
        {
            Id = id;
        }
    }
}
