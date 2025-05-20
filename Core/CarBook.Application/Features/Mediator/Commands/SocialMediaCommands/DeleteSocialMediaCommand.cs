using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class DeleteSocialMediaCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteSocialMediaCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
