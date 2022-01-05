using Models.Entities;

namespace BLL.IService
{
    public interface IProductService
    {
        public Product AddProduct(Product product);
        public Product GetById(int productId);
    }
}
