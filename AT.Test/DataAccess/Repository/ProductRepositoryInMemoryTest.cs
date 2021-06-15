using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    [TestFixture]
    public class ProductRepositoryInMemoryTest
    {
        private IConfigurationRoot _config;
        private ATDbContext _context;
        [SetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var options = new DbContextOptionsBuilder<ATDbContext>().UseInMemoryDatabase(databaseName: "ATWebApi").Options;

            _context = new ATDbContext(options, _config);
        }

        [TestCase("ProductTest1", "ProductTest1")]
        [TestCase("ProductTest2", "ProductTest2")]
        [TestCase("ProductTest3", "ProductTest3")]
        public void ShouldCreateNewProductInMemory(string productName, string expectedProductName)
        {
            var productTobeCreate = new Product { Id = 0, ProductName = productName };

            IRepository<Product> productRepository = new ProductRepository(_context);
            var createdProduct = productRepository.Create(productTobeCreate);

            Assert.AreEqual(createdProduct.ProductName, expectedProductName);
            Assert.Greater(createdProduct.Id, 0);
        }


        [Test]
        public void ShouldGetProductByIdInMemory()
        {
            var productTobeCreate = new Product { Id = 0, ProductName = RandomUtil.GetRandomString("ProductTest") };

            IRepository<Product> productepository = new ProductRepository(_context);
            var createdProduct = productepository.Create(productTobeCreate);

            var productById = productepository.GetById(createdProduct.Id);

            Assert.NotNull(productById);
            Assert.Greater(productById.Id, 0);
        }
        [Test]
        public void ShouldGetAllProductsInMemory()
        {
            var productTobeCreate = new Product { Id = 0, ProductName = RandomUtil.GetRandomString("ProductTest") };

            IRepository<Product> productRepository = new ProductRepository(_context);
            productRepository.Create(productTobeCreate);

            var allProducts = productRepository.GetAll();

            Assert.NotNull(allProducts);
            Assert.True(allProducts.Any());
        }


        [Test]
        public void ShouldDeleteProductInMemory()
        {
            var productTobeCreate = new Product { Id = 0, ProductName = RandomUtil.GetRandomString("ProductTest") };

            IRepository<Product> productepository = new ProductRepository(_context);
            var productToDelete = productepository.Create(productTobeCreate);

            var productIsDeleted = productepository.Delete(productToDelete.Id);

            Assert.True(productIsDeleted);
        }


        [Test]
        public void ShouldUpdateProductInMemory()
        {
            var productTobeCreate = new Product { Id = 0, ProductName = RandomUtil.GetRandomString("ProductTest") };

            IRepository<Product> productepository = new ProductRepository(_context);
            var productToBeUpdate = productepository.Create(productTobeCreate);

            productToBeUpdate.ProductName = RandomUtil.GetRandomString("ProductToUpdate");

            var productUpdated = productepository.Update(productToBeUpdate);

            Assert.NotNull(productUpdated);
            Assert.IsNotEmpty(productUpdated.ProductName);
            Assert.That(productUpdated.ProductName.Contains("ProductToUpdate"));
            Assert.Greater(productUpdated.Id, 0);
        }
    }
}
