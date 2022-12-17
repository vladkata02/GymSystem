namespace GymSystem.API.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
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
        public IActionResult GetUser()
        {
            return this.Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserVO user)
        {
            var token = this.userRepository.Authenticate(user);

            if (token == null)
            {
                return this.Unauthorized("Wrong email or password!");
            }

            var actualUser = this.userRepository.GetByEmail(user.Email);

            var claims = new List<Claim>();
            claims.Add(new Claim("UserId", $"{actualUser.UserId}"));

            await this.ClaimsAsync(claims);

            return this.Ok(new { token });
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return this.Ok();
        }

        private async Task ClaimsAsync(List<Claim> claim)
        {
            var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();
            props.IsPersistent = true;
            await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        private UserVO GetContextUser()
        {
            var identity = this.HttpContext.User.Identity as ClaimsIdentity;

            if (identity.HasClaim(o => o.Type == "UserId"))
            {
                var userClaims = identity.Claims;

                return new UserVO
                {
                    UserId = int.Parse(userClaims.FirstOrDefault(o => o.Type == "UserId")?.Value),
                };
            }

            return null;
        }
    }
}
