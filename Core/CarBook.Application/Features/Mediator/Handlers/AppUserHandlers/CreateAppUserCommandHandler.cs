using CarBook.Application.Enums;
using CarBook.Application.Features.Mediator.Commands.RegisterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;
        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.Username,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                AppUserRoleId = (int)RolesType.Member,
            });
        }
    }
}
