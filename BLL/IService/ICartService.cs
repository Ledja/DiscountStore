using Models;
using Models.DTOs;
using System.Collections.Generic;

namespace BLL.IService
{
    public interface ICartService
    {
        void Add(CartItemEditModel cartItem);
        void Remove(int ProductId);
        decimal GetTotal();        
    }
}
