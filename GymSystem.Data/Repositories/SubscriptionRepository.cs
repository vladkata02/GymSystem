using GymSystem.Data.ViewObjects;
using GymSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private AppDbContext context;

        public SubscriptionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IList<SubscriptionVO> GetAllSubscriptions()
        {
            return this.context.Subscriptions.Select(p => new SubscriptionVO(p)).ToList();
        }

        public void CreateSubscription(SubscriptionVO subscription, int userId)
        {
            this.context.Subscriptions.Add(new Subscription(userId, subscription.DateFrom, subscription.DateTo, subscription.MoneyPaid));
        }
    }
}
