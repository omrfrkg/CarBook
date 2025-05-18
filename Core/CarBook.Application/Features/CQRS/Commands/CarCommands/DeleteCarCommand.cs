namespace CarBook.Application.Features.CQRS.Commands.CarCommands
{
    public class DeleteCarCommand
    {
        public int Id { get; set; }

        public DeleteCarCommand(int id)
        {
            Id = id;
        }
    }
}
