using Xunit;
using Moq;
using BLL.IService;
using Api.Controllers;
using Models;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace UnitTest
{
    public class CheckoutControllerTests
    {
        private readonly Mock<ICartService> _cartService = new();
        private readonly Mock<IProductService> _productService = new();
        private readonly CheckoutController _controller;

        public CheckoutControllerTests()
        {
            _controller = new CheckoutController(_cartService.Object, _productService.Object);
        }

        [Fact]
        public void AddItem_Adds_An_Item_To_The_Cart_Returns_200()
        {
            //Arrange
            var cartItem = new CartItemEditModel
            {
                ProductId = 1,
                Quantity = 1
            };
            _cartService.Setup(i => i.Add(cartItem));

            //Act
            var result = _controller.AddItem(cartItem);

            //Assert
            var actionResult = Assert.IsAssignableFrom<ActionResult>(result);
            Assert.IsAssignableFrom<OkResult>(actionResult);           
        }

        [Fact]
        public void AddItem_Adds_An_Item_To_The_Cart_Returns_BadRequest()
        {
            //Arrange
            var cartItem = new CartItemEditModel();

            //Act
            var result = _controller.AddItem(cartItem);

            //Assert
            var actionResult = Assert.IsAssignableFrom<ActionResult>(result);
            Assert.IsAssignableFrom<BadRequestResult>(actionResult);
        }
    }
}
