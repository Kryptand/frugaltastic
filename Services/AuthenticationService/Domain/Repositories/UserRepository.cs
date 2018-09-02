using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.Domain.Database;
using CrossCutting.Exceptions;
using CrossCutting.Authentication.Logic;
using CrossCutting.Authentication.Models;
using CrossCutting.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Domain.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUserModel>, IUserRepository
    {
        
        public UserRepository(AuthenticationServiceDbContext dbContext) => _context = dbContext;

        public async Task<ApplicationUserModel>FindUserByGuid(Guid userGuid)
        {
            return await FindAsync(x=>x.AuthenticationModelGuid==userGuid);
        }
        public async Task<ApplicationUserModel> LoginAsync(AuthenticationModel authModel)
        {
            var user = await _context.Set<ApplicationUserModel>().Include(model => model.AuthenticationModel)
                .FirstOrDefaultAsync(x =>
                    x.AuthenticationModel.UserIdentification == authModel.UserIdentification &&
                   PasswordEncryptionUtility.ValidateHash(x.AuthenticationModel.Password,authModel.Password,x.AuthenticationModel.Salt));
            return user;
        }


        public async Task<bool> RegisterAsync(AuthenticationModel registerModel,TenantModel tenantModel)
        {
            var findUser = await FindAsync(x =>
                x.AuthenticationModel.UserIdentification == registerModel.UserIdentification);
            if (findUser != null)
            {
                return false;
            }
            var salt=PasswordEncryptionUtility.GenerateSalt();
            registerModel.Salt = Convert.ToBase64String(salt);
            registerModel.Password = PasswordEncryptionUtility.GenerateHash(registerModel.Password,salt);
            var user = new ApplicationUserModel {AuthenticationModel = registerModel,TenantGuid = tenantModel.TenantGuid,Tenant = tenantModel};
            var registerUser = await AddAsync(user);
            if (registerUser <= 0)
            {
                throw new DatabaseConnectionException(_context.Database);
            }

            return true;
        }

      
        public async Task<ICollection<ApplicationUserModel>> GetAllUsersAsync()
        {
            return await GetAllAsync();
        }
    }
    
}
