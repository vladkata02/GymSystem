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
        public Tokens? Authenticate(UserVO user)
        #pragma warning restore CS8766
        {
            var wantedUser = this.context.Users.Where(u => u.Email == user.Email).FirstOrDefault();

            if (wantedUser == null || !BC.Verify(user.Password, wantedUser.PasswordHashed))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserId", $"{user.UserId}")
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
