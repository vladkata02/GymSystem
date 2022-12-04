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
            return this.context.Prices.Select(p => new PriceVO(p))
                                      .OrderBy(p => p.Month)
                                      .ToList();
        }

        public void CreatePrice(PriceVO price, int userId)
        {
            this.context.Prices.Add(new Price(price.Month, price.Amount, price.IsDefaultPrice));
        }
    }
}
