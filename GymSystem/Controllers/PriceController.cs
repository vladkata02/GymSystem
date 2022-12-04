using GymSystem.Data.Repositories;
using GymSystem.Data.ViewObjects;
using Microsoft.AspNetCore.Mvc;

namespace GymSystem.API.Controllers
{
    [Route("api/price")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private IPriceRepository priceRepository;

        public PriceController(IPriceRepository priceRepository)
        {
            this.priceRepository = priceRepository;
        }

        [HttpGet("getAll")]
        public IList<PriceVO> GetPrices()
        {
            return this.priceRepository.GetAllPrices();
        }

        [HttpPost("create")]
        public void CreatePrice(PriceVO price)
        {
            var userId = int.Parse(this.HttpContext.User.Claims.First(c => c.Type == "UserId").Value);

            this.priceRepository.CreatePrice(price, userId);
        }
    }
}
