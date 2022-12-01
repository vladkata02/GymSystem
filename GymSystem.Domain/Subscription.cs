namespace GymSystem.Domain
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }

        public int UserId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public decimal MoneyPaid { get; set; }
    }
}
