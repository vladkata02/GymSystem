namespace GymSystem.API.Controllers
{
    using System;
    using System.Security.Claims;
    using GymSystem.Data.Repositories;
    using GymSystem.Data.ViewObjects;
    using GymSystem.Domain;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult CreateUser(UserVO user)
        {
            if (this.userRepository.CheckIfUsernameExist(user.Username))
            {
                return this.Unauthorized("User with this username already exists!");
            }

            if (this.userRepository.CheckIfEmailExist(user.Email))
            {
                return this.Unauthorized("User with this email already exists!");
            }

            this.userRepository.CreateUser(user);

            var token = this.userRepository.Authenticate(user);

            return this.Ok(token);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("user")]
        public User? GetUser()
        {
            var userId = this.HttpContext.User.FindFirst("UserId");
            if (userId != null)
            {
                return this.userRepository.GetById(int.Parse(userId.Value));
            }

            return null;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate(UserVO user)
        {
            var token = this.userRepository.Authenticate(user);

            if (token == null)
            {
                return this.Unauthorized("Wrong email or password!");
            }

            var claims = new List<Claim>();
            claims.Add(new Claim("UserId", $"{user.UserId}"));

            this.Claims(claims);
            return this.Ok(token);
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return this.Ok();
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
