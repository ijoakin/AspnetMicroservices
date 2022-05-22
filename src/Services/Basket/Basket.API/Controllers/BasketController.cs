using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {

        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger, IBasketRepository basketRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));

        }

        [HttpGet("GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return NotFound();

            var basket = await _basketRepository.GetBasket(userName);

            return Ok(basket ?? new ShoppingCart());
        }
        [HttpPost("UpdateBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart shoppingCart)
        {
            if (string.IsNullOrEmpty(shoppingCart.UserName)) return NotFound();
            return Ok(await _basketRepository.UpdateBasket(shoppingCart));
        }

        [HttpDelete("DeleteBasket")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> DeleteBasket(string userName)
        {
            await _basketRepository.DeleteBasket(userName);
            return Ok();
        }
    }
}
