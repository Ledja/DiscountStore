
using BLL.IService;
using DAL.IRepositories;
using Models.Entities;
using System;

namespace BLL.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public Product GetById(int productId)
        {
            return _productRepository.GetById(productId);
        }
    }
}
