using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IRepository<AppUserRole> _appUserRoleRepository;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository, IRepository<AppUserRole> appUserRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appUserRoleRepository = appUserRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);
            if(user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.Username = user.UserName;
                values.Role = (await _appUserRoleRepository.GetByFilterAsync(x => x.AppUserRoleId == user.AppUserRoleId)).AppUserRoleName;
                values.Id = user.AppUserId;
            }
            return values;
        }
    }
}
