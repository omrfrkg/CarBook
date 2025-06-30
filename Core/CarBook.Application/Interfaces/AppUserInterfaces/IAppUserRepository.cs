using System.Linq.Expressions;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);

    }
}
