namespace GymSystem.Domain;

public class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PasswordHashed { get; set; }

    public bool HasActiveSubscription { get; set; }
}
