using System.Linq;
using AT.DataAccess.Data;
using AT.DataAccess.Repositories;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using AT.Test.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace AT.Test.DataAccess.Repository
{
    public class ProductRepositoryTest
    {
        private ATDbContext _context;
        private IConfiguration _config;

        [SetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<ATDbContext>();
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            _context = new ATDbContext(optionsBuilder.Options, _config);
        }

        [TestCase]
        public void ShouldGetAllProducts()
        {
            
            IRepository<Product> repository = new ProductRepository(_context);

            var productList = repository.GetAll();

            Assert.Greater(productList.Count(),0);
        }

        [Test]
        public void ShouldGetProductById()
        {
            var productToCreate = new Product(){ProductName = RandomUtil.GetRandomString("ProductTest"), IdProductType = 1};

            IRepository<Product> productRepository = new ProductRepository(_context);
            var createdProduct = productRepository.Create(productToCreate);

            var fetchedProduct = productRepository.GetById(createdProduct.Id);

            Assert.NotNull(fetchedProduct);
            Assert.Greater(fetchedProduct.Id, 0);

        }



        [Test]
        public void ShouldCreateProduct()
        {
            var productTobeCreate = new Product() { ProductName = RandomUtil.GetRandomString("ProductTest"), IdProductType = 1};

            IRepository<Product> productRepository = new ProductRepository(_context);
            var createdproduct = productRepository.Create(productTobeCreate);

            Assert.NotNull(createdproduct);
            Assert.IsNotEmpty(createdproduct.ProductName);
            Assert.Greater(createdproduct.Id, 0);
        }



        [Test]
        public void ShouldDeleteProduct()
        {
            var productTobeCreate = new Product { ProductName = RandomUtil.GetRandomString("TestProduct"), IdProductType = 1};

            IRepository<Product> productRepository = new ProductRepository(_context);
            var createdProduct = productRepository.Create(productTobeCreate);

            var productIsDeleted = productRepository.Delete(createdProduct.Id);

            Assert.True(productIsDeleted);
        }

        [Test]
        public void ShouldUpdateProduct()
        {
            var productTobeCreate = new Product { ProductName = RandomUtil.GetRandomString("TestProduct"), IdProductType = 1 };

            IRepository<Product> productRepository = new ProductRepository(_context);
            var productToBeUpdate = productRepository.Create(productTobeCreate);

            productToBeUpdate.ProductName = RandomUtil.GetRandomString("ProductToUpdate");

            var productUpdated = productRepository.Update(productToBeUpdate);

            Assert.NotNull(productUpdated);
            Assert.IsNotEmpty(productUpdated.ProductName);
            Assert.That(productUpdated.ProductName.Contains("ProductToUpdate"));
            Assert.Greater(productUpdated.Id, 0);
        }
    }
}
