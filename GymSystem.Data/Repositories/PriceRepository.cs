using GymSystem.Data.ViewObjects;
using GymSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private AppDbContext context;

        public PriceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IList<PriceVO> GetAllPrices()
        {
            var prices = this.context.Prices.OrderBy(p => p.Months)
                                            .Select(p => new PriceVO(p))
                                            .ToList();

            var defaultPrice = prices.FirstOrDefault(p => p.IsDefaultPrice);
            if (defaultPrice != null)
            {
                prices.Remove(defaultPrice);
                prices.Insert(0, defaultPrice);
            }

            return prices;
        }

        public void CreatePrice(PriceVO price, int userId)
        {
            var prices = this.context.Prices.ToList();

            if (price.IsDefaultPrice)
            {
                var defaultPrice = prices.Where(p => p.IsDefaultPrice).FirstOrDefault();
                this.RemovePriceIfNotNull(defaultPrice);
            }
            else {
                var priceMatchingMonth = prices.Where(p => p.Months == price.Months).FirstOrDefault();
                this.RemovePriceIfNotNull(priceMatchingMonth);
            }

            this.context.Prices.Add(new Price(price.Months, price.Amount, price.IsDefaultPrice));

            this.context.SaveChanges();
        }

        private void RemovePriceIfNotNull(Price? price)
        {
            if(price != null)
            {
                this.context.Prices.Remove(price);
            }
        }
    }
}
