using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands
{
    public class DeleteBlogCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteBlogCommand(int id)
        {
            Id = id;
        }
    }
}
