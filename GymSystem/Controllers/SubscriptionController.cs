using GymSystem.Data.Repositories;
using GymSystem.Data.ViewObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymSystem.API.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private ISubscriptionRepository subscriptionRepository;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        [Authorize]
        [HttpGet("list")]
        public IList<SubscriptionVO> GetSubscriptions()
        {
            var user = this.GetContextUser();

            return this.subscriptionRepository.GetAllSubscriptions(user.UserId);
        }

        [Authorize]
        [HttpPost("create")]
        public void CreateSubscription(SubscriptionVO subscription)
        {
            var user = this.GetContextUser();

            this.subscriptionRepository.CreateSubscription(subscription, user.UserId);
        }

        private UserVO GetContextUser()
        {
            var identity = this.HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserVO
                {
                    UserId = int.Parse(userClaims.FirstOrDefault(o => o.Type == "UserId")?.Value),
                };
            }

            return null;
        }
    }
}
