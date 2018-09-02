using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossCutting.Authentication.Models;
using CrossCutting.Data;
using CrossCutting.Data.Contracts;

namespace AuthenticationService.Domain.Repositories
{
    public class TenantRepository:GenericRepository<TenantModel>
    {
    }
}
