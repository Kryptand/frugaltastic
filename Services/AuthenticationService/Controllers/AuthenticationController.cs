using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using AuthenticationService.Domain.Repositories;
using CrossCutting.Authentication.Config;
using CrossCutting.Authentication.Logic;
using CrossCutting.Authentication.Models;
using CrossCutting.Data.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private IConfiguration _config;

        private const string Usernotfound = "The given credentials do not match an existing user";
        private const string UserCreatedSuccessfully = "The User has been created successfully";
        private const string UserAlreadyExists = "The User has already been created";
        private readonly IUserRepository _userRepository;
        private readonly IGenericRepository<TenantModel> _tenantRepository;

        public AuthenticationController(IUserRepository userRepository, IConfiguration config,IGenericRepository<TenantModel> tenantRepository)
        {
            _userRepository = userRepository;
            _config = config;
            _tenantRepository = tenantRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticationModel authenticationModel)
        {
            if (!ModelState.IsValid) return BadRequest(authenticationModel);
            var login = await _userRepository.LoginAsync(authenticationModel);

            if (login == null)
                return (IActionResult) new NotAcceptableObjectResult(new JsonResult(Usernotfound));
            else
            {
                var httpConnectionFeature = HttpContext.Features.Get<IHttpConnectionFeature>();
                var localIpAddress = httpConnectionFeature?.LocalIpAddress;
                if (localIpAddress != null)
                {
                    var jwtSettings = new JwtSettings
                    {
                        Issuer = localIpAddress.ToString(),
                        Audience = localIpAddress.ToString(),
                        ExpirationTime = 30,
                        JwtId = new Guid().ToString(),
                        NotBefore = new DateTime(),
                        Tenant = login.TenantGuid.ToString()
                    };

                    return new OkObjectResult(
                        new JwtSecurityTokenHandler().WriteToken(JwtUtility.BuildToken(login, _config["Jwt:Key"],
                            jwtSettings)));
                }
                else
                {
                    return BadRequest();
                }
            }
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AuthenticationModel authenticationModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var tenantModel = new TenantModel {Description = authenticationModel.UserIdentification, TenantGuid = new Guid()};
            var register = await _userRepository.RegisterAsync(authenticationModel,tenantModel);

            if (!register)
            {
                return new JsonResult(UserAlreadyExists);
            }
            await _tenantRepository.AddAsync(tenantModel);
            return new OkObjectResult(UserCreatedSuccessfully);
        }
    }
}