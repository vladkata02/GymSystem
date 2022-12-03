namespace GymSystem.API.Controllers
{
    using System;
    using System.Security.Claims;
    using GymSystem.Data.Repositories;
    using GymSystem.Data.ViewObjects;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("create")]
        public void CreateUser(UserVO user)
        {
            this.userRepository.CreateUser(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserVO user)
        {
            var token = this.userRepository.Authenticate(user);

            if (token == null)
            {
                return this.Unauthorized();
            }

            var claims = new List<Claim>();
            claims.Add(new Claim("UserId", $"{user.UserId}"));

            this.Claims(claims);
            return this.Ok(token);
        }

        private void Claims(List<Claim> claim)
        {
            var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();
            props.IsPersistent = true;
            this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
        }
    }
}
