using GymSystem.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.ViewObjects
{
    public class PostVO
    {
        public PostVO()
        {
        }

        public PostVO(Post post)
        {
            this.PostId = post.PostId;
            this.Title = post.Title;
            this.Description = post.Description;
            this.CreateDate = post.CreateDate;
            this.UserId = post.UserId;
            this.ImageLink = post.ImageLink;
        }

        public int? PostId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? UserId { get; set; }

        public string? Username { get; set; }

        public string ImageLink { get; set; }
    }
}
