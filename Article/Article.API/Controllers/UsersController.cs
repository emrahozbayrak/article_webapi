using Article.Core.Models;
using Article.Core.Services;
using Article.Core.Utilities.Results;
using Article.Core.Utilities.UserResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // /api/users/login
        [HttpPost("login")]
        public async Task<IUserResult> LoginAsync(AuthenticateUserModel model)
        {
            return await _userService.LoginAsync(model);
        }


        // /api/users/register
        [HttpPost("register")]
        public async Task<IResult> RegisterAsync(CreateUserModel model)
        {
            return await _userService.RegisterAsync(model);
        }

        [HttpPut]
        public IResult Update(UpdateUserModel model)
        {
            return _userService.UpdateUser(model);
        }

        // /api/users/{id}
        [HttpDelete("{id}")]
        public IResult Delete(long id)
        {
            return _userService.DeleteUser(id);
        }
    }
}
