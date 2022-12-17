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

        public IList<SubscriptionVO> GetAllSubscriptions(int userId)
        {
            return this.context.Subscriptions.Where(s => s.UserId == userId)
                                             .OrderByDescending(s => s.DateTo)
                                             .Select(s => new SubscriptionVO(s))
                                             .ToList();
        }

        public void CreateSubscription(SubscriptionVO subscription, int userId)
        {
            var currentUserSubscriptions = this.context.Subscriptions.Where(s => s.UserId == userId).ToList();

            if (!currentUserSubscriptions.Any())
            {
                subscription.DateFrom = DateTime.Now;
            }
            else
            {
                if (currentUserSubscriptions.Last().DateTo < DateTime.Now)
                {
                    subscription.DateFrom = DateTime.Now;
                }
                else
                {
                    subscription.DateFrom = currentUserSubscriptions.Last().DateTo;
                }
            }

            subscription.DateTo = subscription.DateFrom.AddMonths(subscription.Months);

            this.context.Subscriptions.Add(new Subscription(userId, subscription.DateFrom, subscription.DateTo, subscription.MoneyPaid));

            this.context.SaveChanges();
        }
    }
}
