using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands
{
    public class DeletePricingCommand : IRequest
    {
        public int Id { get; set; }

        public DeletePricingCommand(int id)
        {
            Id = id;
        }
    }
}
