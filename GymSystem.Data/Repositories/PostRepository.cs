using GymSystem.Data.ViewObjects;
using GymSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private AppDbContext context;

        public PostRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IList<PostVO> GetAllPosts()
        {
            return this.context.Posts.Select(p => new PostVO(p))
                                     .OrderBy(p => p.CreateDate)
                                     .ToList();
        }

        public void CreatePost(PostVO post, int userId)
        {
            this.context.Posts.Add(new Post(post.Description, post.CreateDate, post.UserId, post.ImageContent));
        }
    }
}
