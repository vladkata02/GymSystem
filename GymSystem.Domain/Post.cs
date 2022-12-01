namespace GymSystem.Domain
{
    public class Post
    {
        public int PostId { get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }

        public byte[]? ImageContent { get; set; }
    }
}
