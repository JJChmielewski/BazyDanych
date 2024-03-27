using BLL.DTOModels;
using BLL_DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazyDanych.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDBController : ControllerBase
    {

        private OrderServiceDB service = new OrderServiceDB();

        [HttpPost]
        public void addProductToBasket([FromQuery] int productId, [FromQuery] int userId)
        {
            service.addProductToBasket(productId, userId);
        }

        [HttpGet]
        public OrderResponseDTO generateOrder([FromQuery] int userId)
        {
            return service.generateOrder(userId);
        }

        [HttpPut]
        public void updateQuantity([FromQuery] int productId, [FromQuery] int basketId, [FromQuery] int quantity)
        {
            service.updateProductQuantityInBasket(productId, basketId, quantity);
        }

        [HttpDelete]
        public void deleteProdFromBasket([FromQuery] int productId, [FromQuery] int basketId)
        {
            service.removeProductFromBasket(productId, basketId);
        }

        [HttpPost]
        [Route("pay")]
        public void payForOrder([FromQuery] int orderId, [FromQuery] double payment)
        {
            service.payForOrder(orderId, payment);
        }
    }
}
