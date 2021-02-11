using Article.Core.Entities;
using Article.Core.Models;
using Article.Core.Repositories;
using Article.Core.Services;
using Article.Core.Utilities.Results;
using Article.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service
{
    public class UserService : IUserService
    {
        private readonly ArticleDBContext _context;
        private readonly IUserRepository _userRepo;

        public UserService(ArticleDBContext Context, IUserRepository userRepo)
        {
            _context = Context;
            _userRepo = userRepo;
        }

        public Task<IDataResult<User>> LoginAsync(AuthenticateRequest model)
        {
            throw new NotImplementedException();
        }
        public async Task<IResult> RegisterAsync(RegisterRequest model)
        {
            if (model == null) return new ErrorResult("Data is null");

            if (string.IsNullOrEmpty(model.Password)) return new ErrorResult("Password is required");

            if (_userRepo.UserNameExist(model.UserName)) return new ErrorResult($"Username {model.UserName} is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);

            var user = new Article.Core.Entities.User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _userRepo.InsertAsync(user);
            return new SuccessResult("User created successfully!");

        }
        public Task<IResult> UpdateUser(User model)
        {
            throw new NotImplementedException();
        }
        public Task<IResult> DeleteUser(User model)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteUser(long id)
        {
            throw new NotImplementedException();
        }


        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

   
    }
}
