namespace GymSystem.Domain
{
    public class Price
    {
        public int PriceId { get; set; }

        public int Month { get; set; }

        public decimal Amount { get; set; }

        public bool IsDefaultPrice { get; set; }
    }
}
