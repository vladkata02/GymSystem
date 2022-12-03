using GymSystem.Data.Utilities;
using GymSystem.Data.ViewObjects;
using GymSystem.Domain;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private const int SaltSize = 16;
        private const int HashSize = 20;

        public UserRepository(AppDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public void CreateUser(UserVO user)
        {
            this.context.Users.Add(new User(user.Username, user.Email, this.Hashed(user.Password), false));
            this.context.SaveChanges();
        }

        #pragma warning disable CS8766
        public Tokens? Authenticate(UserVO user)
        #pragma warning restore CS8766
        {
            var wantedUser = this.context.Users.Where(u => u.Username == user.Username);

            if (wantedUser.Any())
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("UserId", $"{user.UserId}")
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

        private string Hashed(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100,
                numBytesRequested: 256 / 8));
        }

    }
}
