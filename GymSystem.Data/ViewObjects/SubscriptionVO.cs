using GymSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.ViewObjects
{
    public class SubscriptionVO
    {
        public SubscriptionVO(Subscription subscription)
        {
            SubscriptionId = subscription.SubscriptionId;
            UserId = subscription.UserId;
            DateFrom = subscription.DateFrom;
            DateTo = subscription.DateTo;
            MoneyPaid = subscription.MoneyPaid;
        }

        public int SubscriptionId { get; set; }

        public int UserId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public decimal MoneyPaid { get; set; }
    }
}
