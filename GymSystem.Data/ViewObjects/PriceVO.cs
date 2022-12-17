using GymSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.ViewObjects
{
    public class PriceVO
    {
        public PriceVO(Price price)
        {
            this.PriceId = price.PriceId;
            this.Months = price.Months;
            this.Amount = price.Amount;
            this.IsDefaultPrice = price.IsDefaultPrice;
        }

        public int PriceId { get; set; }

        public int Months { get; set; }

        public decimal Amount { get; set; }

        public bool IsDefaultPrice { get; set; }
    }
}
