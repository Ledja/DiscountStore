using BLL.IService;
using DAL.IRepositories;
using Models;
using Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Service
{
    public class CartService : ICartService
    {
        
        private readonly IProductRepository _productRepository;
        private readonly List<CartItem> _cartItems;
        public CartService(IProductRepository productRepository, List<CartItem> cartItems)
        {
            _productRepository = productRepository;
            _cartItems = cartItems;
        }
        public void Add(CartItemEditModel cartItem)
        {
            var product = _productRepository.GetById(cartItem.ProductId);
            if (!_cartItems.Any(i => i.ProductId == cartItem.ProductId))
            {
                _cartItems.Add(new CartItem(cartItem.ProductId, product.Price, cartItem.Quantity));
                return;
            }
            var existingItem = _cartItems.FirstOrDefault(i => i.ProductId == cartItem.ProductId);
            existingItem.AddQuantity(cartItem.Quantity);
        }
        public decimal GetTotal()
        {
            decimal totalPrice = 0;

            foreach (var item in _cartItems)
            {
                totalPrice += ItemTotal(item);
            }

            return totalPrice;
        }

        public decimal ItemTotal(CartItem item)
        {
            var product = _cartItems.FirstOrDefault(i => i.ProductId == item.ProductId);
            var initialPrice = (product.UnitPrice * product.Quantity);
            if (product.Quantity < 2)
                return initialPrice;
            else
            {
                var discount = GetDiscount(item, initialPrice);
                return initialPrice - discount;
            }

        }
        public decimal GetDiscount(CartItem item, decimal total)
        {
            var product = _productRepository.GetById(item.ProductId);

            if (product != null)
            {
                return product.Discount / 100 * total;
            }

            return 0;
        }

        public void Remove(int productId)
        {
            var cartItem =  GetAllItems().FirstOrDefault(i => i.ProductId == productId);
            _cartItems.Remove(cartItem);
        }

        private  IList<CartItem> GetAllItems()
        {
            return _cartItems;
        }
    }
}

