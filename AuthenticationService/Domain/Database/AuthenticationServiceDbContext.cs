using CrossCutting.Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Domain.Database
{
    public class AuthenticationServiceDbContext:DbContext
    {
        public AuthenticationServiceDbContext(DbContextOptions<AuthenticationServiceDbContext> options)
            : base(options)
        {}

        public DbSet<ApplicationUserModel> Users{get;set;}
        public DbSet<AuthenticationModel> AuthenticationCredentials { get; set; }
        public DbSet<TenantModel> Tenants { get; set; }

    }
}
