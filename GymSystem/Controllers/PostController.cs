using System.Security.Claims;
using GymSystem.Data.Repositories;
using GymSystem.Data.ViewObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymSystem.API.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostRepository postRepository;

        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpGet("list")]
        public IList<PostVO>? GetPosts()
        {
            return this.postRepository.GetAllPosts();
        }

        [Authorize]
        [HttpPost("create")]
        public void CreatePost(PostVO post)
        {
            var user = this.GetContextUser();

            this.postRepository.CreatePost(post, user.UserId);
        }

        private UserVO GetContextUser()
        {
            var identity = this.HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
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
