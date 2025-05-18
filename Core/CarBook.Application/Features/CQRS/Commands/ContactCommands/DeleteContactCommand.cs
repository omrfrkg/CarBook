namespace CarBook.Application.Features.CQRS.Commands.ContactCommands
{
    public class DeleteContactCommand
    {
        public int Id { get; set; }

        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }
}
