using System;
using System.Threading.Tasks;
using CrossCutting.Authentication.Models;
using CrossCutting.Data.Contracts;

namespace AuthenticationService.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<ApplicationUserModel>
    {
        Task<ApplicationUserModel> FindUserByGuid(Guid userGuid);
        Task<ApplicationUserModel> LoginAsync(AuthenticationModel authModel);
        Task<bool> RegisterAsync(AuthenticationModel registerModel,TenantModel tenantModel);

    }
}