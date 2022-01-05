using BLL.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using Models.Entities;
using System.Linq;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
       
        private  readonly ICartService _cartService;
        private  readonly IProductService _productService;
        public CheckoutController(ICartService cartService, IProductService productService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        [HttpGet("GetTotal")]
        public ActionResult<decimal> Index()
        {
            return _cartService.GetTotal();
        }

        [HttpPost("AddProduct")]
        public ActionResult<Product> AddProduct(Product product)
        {
            if (product == null)
                return BadRequest();

            return Ok(_productService.AddProduct(product));
            
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem(CartItemEditModel cartItem)
        {
            if (cartItem.ProductId ==0 || cartItem.Quantity == 0)
                return BadRequest();
           
            _cartService.Add(cartItem);
            return Ok();          
            
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(int productId)
        {

            if (productId <= 0)
                return BadRequest();

            _cartService.Remove(productId);
            return Ok();
        }
    }
}
