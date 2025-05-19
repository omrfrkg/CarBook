using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class DeleteFooterAddressCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteFooterAddressCommand(int id)
        {
            Id = id;
        }
    }
}
