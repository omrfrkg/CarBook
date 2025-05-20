using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class DeleteTestimonialCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteTestimonialCommand(int id)
        {
            Id = id;
        }
    }
}
