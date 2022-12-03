using GymSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.ViewObjects
{
    public class PostVO
    {
        public PostVO(Post post)
        {
            PostId = post.PostId;
            Description = post.Description;
            CreateDate = post.CreateDate;
            UserId = post.UserId;
            ImageContent = post.ImageContent;
        }

        public int PostId { get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }

        public byte[]? ImageContent { get; set; }
    }
}
