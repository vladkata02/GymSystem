namespace GymSystem.Domain
{
    public class Price
    {
        public Price()
        {
        }

        public Price(int? months, decimal amount, bool isDefaultPrice)
        {
            Months = months;
            Amount = amount;
            IsDefaultPrice = isDefaultPrice;
        }

        public int PriceId { get; set; }

        public int? Months { get; set; }

        public decimal Amount { get; set; }

        public bool IsDefaultPrice { get; set; }
    }
}
