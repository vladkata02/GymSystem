using GymSystem.Data.Utilities;
using GymSystem.Data.ViewObjects;
using GymSystem.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BC = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext context;
        private readonly IConfiguration configuration;

        public UserRepository(AppDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public User? GetById(int userId)
        {
            return this.context.Users.Find(userId);
        }

        public User GetByEmail(string email)
        {
            return this.context.Users.Where(u => u.Email == email).First();
        }

        public bool CheckIfUsernameExist(string username)
        {
            return this.context.Users.Where(u => u.Username == username).Any();
        }

        public bool CheckIfEmailExist(string email)
        {
            return this.context.Users.Where(u => u.Email == email).Any();
        }

        public void CreateUser(UserVO user)
        {
            var hashedPassword = BC.HashPassword(user.Password);
            this.context.Users.Add(new User(user.Username, user.Email, hashedPassword, false));
            this.context.SaveChanges();
        }

#pragma warning disable CS8766
        public string Authenticate(UserVO user)
#pragma warning restore CS8766
        {
            var wantedUser = this.context.Users.Where(u => u.Email == user.Email).FirstOrDefault();

            if (wantedUser == null || !BC.Verify(user.Password, wantedUser.PasswordHashed))
            {
                return null;
            }

            return this.CreateToken(wantedUser.UserId);
        }

        public string CreateToken(int userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
