namespace GymSystem.Domain
{
    public class Post
    {
        public Post(string title, string description, int userId, string imageLink)
        {
            this.Title = title;
            this.Description = description;
            this.CreateDate = DateTime.Now;
            this.UserId = userId;
            this.ImageLink = imageLink;
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }

        public string ImageLink { get; set; }
    }
}
