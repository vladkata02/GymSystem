using GymSystem.Data.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.Repositories
{
    public interface IPriceRepository
    {
        IList<PriceVO> GetAllPrices();

        void CreatePrice(PriceVO price, int userId);
    }
}
