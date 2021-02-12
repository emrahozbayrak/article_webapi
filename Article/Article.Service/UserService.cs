using Article.Core.Entities;
using Article.Core.Models;
using Article.Core.Repositories;
using Article.Core.Services;
using Article.Core.Utilities.Helpers;
using Article.Core.Utilities.Results;
using Article.Core.Utilities.UserResults;
using Article.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service
{
    public class UserService : IUserService
    {
        private readonly ArticleDBContext _context;
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;

        public UserService(ArticleDBContext Context, IUserRepository userRepo, IConfiguration configuration)
        {
            _context = Context;
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public Article.Core.Entities.User GetById(long id)
        {
            return _userRepo.GetById(id);
        }
        public async Task<IUserResult> LoginAsync(AuthenticateUserModel model)
        {
            if (model == null) return new ErrorUserResult("Data is null");
            if (string.IsNullOrEmpty(model.UserName)) return new ErrorUserResult("UserName is required");
            if (string.IsNullOrEmpty(model.Password)) return new ErrorUserResult("Password is required");

            var user = await _userRepo.LoginAsync(model);
            if (user == null) return new ErrorUserResult("User is not found");

            if (!Functions.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return new ErrorUserResult("Invalid password");

            var claims = new[]
            {
                new Claim(type:"Username", value: user.UserName),
                new Claim(type:ClaimTypes.NameIdentifier,value: user.Id.ToString()),
                new Claim(type:"FirstName", value: user.FirstName),
                new Claim(type:"LastName", value:user.LastName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
            var token = new JwtSecurityToken(
             issuer: _configuration["AuthSettings:Issuer"],
             audience: _configuration["AuthSettings:Audience"],
             claims: claims,
             expires: DateTime.Now.AddYears(1),
             signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new SuccessUserResult(claims.ToDictionary(c => c.Type, c => c.Value), token.ValidTo, tokenAsString);
        }
        public async Task<IResult> RegisterAsync(CreateUserModel model)
        {
            if (model == null) return new ErrorResult("Data is null");

            if (string.IsNullOrEmpty(model.Password)) return new ErrorResult("Password is required");

            if (_userRepo.UserNameExist(model.UserName)) return new ErrorResult($"Username {model.UserName} is already taken");

            byte[] passwordHash, passwordSalt;
            Functions.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);

            var user = new Article.Core.Entities.User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _userRepo.InsertAsync(user);
            return new SuccessResult("User create successfully!");

        }
        public IResult UpdateUser(UpdateUserModel model)
        {
            if (model == null) return new ErrorResult("Data is null");
            if (model.Id == 0) return new ErrorResult("Data Id is required");
            if (string.IsNullOrEmpty(model.UserName)) return new ErrorResult("Username is required");
            if (string.IsNullOrEmpty(model.Password)) return new ErrorResult("Password is required");
            if (string.IsNullOrEmpty(model.FirstName)) return new ErrorResult("First Name is required");
            if (string.IsNullOrEmpty(model.LastName)) return new ErrorResult("Last Name is required");

            var user = _userRepo.GetById(model.Id);

            if (user.UserName != model.UserName && _userRepo.UserNameExist(model.UserName))
                return new ErrorResult($"Email '{model.UserName}' is already taken");

            if (!string.IsNullOrEmpty(model.Password))
            {
                byte[] passwordHash, passwordSalt;
                Functions.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;


            _userRepo.Update(user);
            return new SuccessResult("User update successfully!");
        }
        public IResult DeleteUser(User model)
        {
            _userRepo.Delete(model);
            return new SuccessResult("User delete successfully!");
        }
        public IResult DeleteUser(long id)
        {
            _userRepo.Delete(id);
            return new SuccessResult("User delete successfully!");
        }
    }
}
