using GymSystem.Data.Repositories;
using GymSystem.Data.ViewObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymSystem.API.Controllers
{
    [Route("api/prices")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private IPriceRepository priceRepository;

        public PriceController(IPriceRepository priceRepository)
        {
            this.priceRepository = priceRepository;
        }

        [HttpGet("list")]
        public IList<PriceVO> GetPrices()
        {
            return this.priceRepository.GetAllPrices();
        }

        [Authorize]
        [HttpPost("create")]
        public void CreatePrice(PriceVO price)
        {
            var userId = this.GetContextUser().UserId;

            this.priceRepository.CreatePrice(price, userId);
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
