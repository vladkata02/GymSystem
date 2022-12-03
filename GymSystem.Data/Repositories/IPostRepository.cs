using GymSystem.Data.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.Repositories
{
    public interface IPostRepository
    {
        IList<PostVO> GetAllPosts();

        void CreatePost(PostVO post, int userId);
    }
}
