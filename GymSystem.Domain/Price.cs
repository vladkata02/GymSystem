namespace GymSystem.Domain
{
    public class Price
    {
        public Price(int month, decimal amount, bool isDefaultPrice)
        {
            Month = month;
            Amount = amount;
            IsDefaultPrice = isDefaultPrice;
        }

        public int PriceId { get; set; }

        public int Month { get; set; }

        public decimal Amount { get; set; }

        public bool IsDefaultPrice { get; set; }
    }
}
