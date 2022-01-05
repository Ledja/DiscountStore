using DAL.IRepositories;
using Models.Entities;
using System.Linq;
namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Product AddProduct(Product product)
        {
            _dataContext.Add(product);
            _dataContext.SaveChanges();

            return product;
        }

        public Product GetById(int productId)
        {
            return _dataContext.Find<Product>(productId);
        }
    }
}
