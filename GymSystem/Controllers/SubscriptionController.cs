using GymSystem.Data.Repositories;
using GymSystem.Data.ViewObjects;
using Microsoft.AspNetCore.Mvc;

namespace GymSystem.API.Controllers
{
    [Route("api/subscribtion")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private ISubscriptionRepository subscriptionRepository;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        [HttpGet("getAll")]
        public IList<SubscriptionVO> GetSubscriptions()
        {
            return this.subscriptionRepository.GetAllSubscriptions();
        }

        [HttpPost("create")]
        public void CreateSubscription(SubscriptionVO subscription)
        {
            var userId = int.Parse(this.HttpContext.User.Claims.First(c => c.Type == "UserId").Value);

            this.subscriptionRepository.CreateSubscription(subscription, userId);
        }
    }
}
