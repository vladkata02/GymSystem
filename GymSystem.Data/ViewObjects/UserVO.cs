namespace GymSystem.Data.ViewObjects
{
    public class UserVO
    {
        public UserVO()
        {
        }

        public int UserId { get; set; }

        public string? Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool HasActiveSubscription { get; set; }
    }
}
