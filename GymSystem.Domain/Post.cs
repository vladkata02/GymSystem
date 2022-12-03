namespace GymSystem.Domain
{
    public class Post
    {
        public Post(string? description, DateTime createDate, int userId, byte[]? imageContent)
        {
            Description = description;
            CreateDate = createDate;
            UserId = userId;
            ImageContent = imageContent;
        }

        public int PostId { get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }

        public byte[]? ImageContent { get; set; }
    }
}
