

using Models.Entities;

namespace DAL.IRepositories
{
    public interface IProductRepository
    {
        public Product AddProduct(Product product);
        public Product GetById(int productId);
    }
}
