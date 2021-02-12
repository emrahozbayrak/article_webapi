using Article.Core.Models;
using Article.Core.Services;
using Article.Core.Utilities.Results;
using Article.Core.Utilities.UserResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
        }

        // /api/users/login
        [HttpPost("login")]
        public async Task<IUserResult> LoginAsync(AuthenticateUserModel model)
        {
            var result = await _userService.LoginAsync(model);
            _logger.LogInformation($"Login is success");

            return result;
        }


        // /api/users/register
        [HttpPost("register")]
        public async Task<IResult> RegisterAsync(CreateUserModel model)
        {
            var result = await _userService.RegisterAsync(model);
            _logger.LogInformation($"Register is success");

            return result;
        }

        [HttpPut]
        public IResult Update(UpdateUserModel model)
        {
            var result = _userService.UpdateUser(model);
            _logger.LogInformation($"{nameof(User)} Update is success");

            return result;
        }

        // /api/users/{id}
        [HttpDelete("{id}")]
        public IResult Delete(long id)
        {
            var result = _userService.DeleteUser(id);
            _logger.LogInformation($"{nameof(User)} Delete is success");

            return result;
        }
    }
}
