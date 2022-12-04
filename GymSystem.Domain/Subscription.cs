namespace GymSystem.Domain
{
    public class Subscription
    {
        public Subscription(int userId, DateTime dateFrom, DateTime dateTo, decimal moneyPaid)
        {
            UserId = userId;
            DateFrom = dateFrom;
            DateTo = dateTo;
            MoneyPaid = moneyPaid;
        }

        public int SubscriptionId { get; set; }

        public int UserId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public decimal MoneyPaid { get; set; }
    }
}
