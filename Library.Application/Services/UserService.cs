using Library.Application.Interfaces;
using Library.Application.Services.Auth;
using Library.DataAccess.Interfaces;
using Library.DataAccess.Repositories;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;

        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public async Task<List<BookInstance>> GetBookInstancesByUserIdAsync(Guid id)
        {
            return await _userRepository.GetBookInstancesByUserIdAsync(id);
        }
        public async Task<Guid> RegisterUserAsync(string username, string password, string firstName, string lastName, string email)
        {
            var user = new User
            {
                UserName = username,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return user.Id;
            }
            else
            {
                throw new Exception("User registration failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
        public async Task<(string token, Guid userId)> GenerateJwtTokenAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                throw new Exception("Invalid credentials");
            }


            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName)
                };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return (token, user.Id);
        }


        //public async Task<bool> AuthenticateUserAsync(string username, string password)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

        //    return result.Succeeded;
        //}

        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            // Найти пользователя по имени
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return false; // Пользователь не найден
            }

            // Проверить пароль пользователя
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            return isPasswordValid;
        }


        public async Task<bool> UpdateUserAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid user ID.", nameof(id));
            return await _userRepository.DeleteAsync(id);
        }
    }
}
