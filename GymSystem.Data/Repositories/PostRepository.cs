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
            return (from p in this.context.Posts
                   join u in this.context.Users on p.UserId equals u.UserId
                   select new PostVO
                   {
                       PostId = p.PostId,
                       Title = p.Title,
                       Description = p.Description,
                       ImageLink = p.ImageLink,
                       CreateDate = p.CreateDate,
                       Username = u.Username,
                       UserId = u.UserId
                   }).OrderByDescending(p => p.CreateDate).ToList();
        }

        public void CreatePost(PostVO post, int userId)
        {
            this.context.Posts.Add(new Post(post.Title, post.Description, userId, post.ImageLink));
            this.context.SaveChanges();
        }
    }
}
