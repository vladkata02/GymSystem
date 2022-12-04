using GymSystem.Data.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.Repositories
{
    public interface ISubscriptionRepository
    {
        IList<SubscriptionVO> GetAllSubscriptions();

        void CreateSubscription(SubscriptionVO post, int userId);
    }
}
