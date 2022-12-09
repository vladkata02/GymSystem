namespace GymSystem.Domain;

public class User
{
    public User()
    {
    }

    public User(string? username, string? email, string? passwordHashed, bool hasActiveSubscription)
    {
        Username = username;
        Email = email;
        PasswordHashed = passwordHashed;
        HasActiveSubscription = hasActiveSubscription;
    }

    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PasswordHashed { get; set; }

    public bool HasActiveSubscription { get; set; }
}
