using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteAuthorCommand(int id)
        {
            Id = id;
        }
    }
}
