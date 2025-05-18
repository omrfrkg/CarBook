namespace CarBook.Application.Features.CQRS.Commands.BannerCommands
{
    public class DeleteBannerCommand
    {
        public int Id { get; set; }

        public DeleteBannerCommand(int id)
        {
            Id = id;
        }
    }
}
