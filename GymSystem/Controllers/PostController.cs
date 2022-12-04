using GymSystem.Data.Repositories;
using GymSystem.Data.ViewObjects;
using Microsoft.AspNetCore.Mvc;

namespace GymSystem.API.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostRepository postRepository;

        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpGet("getAll")]
        public IList<PostVO> GetPosts()
        {
            return this.postRepository.GetAllPosts();
        }

        [HttpPost("create")]
        public void CreatePost(PostVO post)
        {
            var userId = int.Parse(this.HttpContext.User.Claims.First(c => c.Type == "UserId").Value);

            this.postRepository.CreatePost(post, userId);
        }
    }
}
