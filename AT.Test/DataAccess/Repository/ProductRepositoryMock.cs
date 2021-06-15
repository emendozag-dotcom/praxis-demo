using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AT.DataAccess.Data;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using AT.Test.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace AT.Test.DataAccess.Repository
{
    [TestFixture]
    public class ProductRepositoryMock
    {
        private IConfigurationRoot _config;
        private ATDbContext _context;

        [SetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<ATDbContext>();
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            _context = new ATDbContext(optionsBuilder.Options, _config);
        }

        [TestCase("ProductTest1", "ProductTest1",1)]
        [TestCase("ProductTest2", "ProductTest2",2)]
        [TestCase("ProductTest3", "ProductTest3",3)]
        public void ShouldCallCreateProductWithMoq(string productname, string expectedProductname, int expectedId)
        {
            var productToBeCreated = new Product { ProductName = productname };
            var mock = new Mock<IRepository<Product>>();
            mock.Setup(p => p.Create(productToBeCreated)).Returns(new Product { ProductName = productname, Id = expectedId });

            var repo = mock.Object;
            var createdProduct = repo.Create(productToBeCreated);

            Assert.AreEqual(createdProduct.ProductName, expectedProductname);
            Assert.AreEqual(createdProduct.Id, expectedId);
        }

        [Test]
        public void ShouldGetAllProductsWithMoq()
        {
            var mock = new Mock<IRepository<Product>>();

            mock.Setup(s => s.GetAll()).Returns(new List<Product> { new Product { Id = 1, ProductName = RandomUtil.GetRandomString("TestProduct") }, new Product { Id = 1, ProductName = RandomUtil.GetRandomString("TestProduct") } }).Verifiable();

            var repo = mock.Object;

            var allProducts = repo.GetAll();


            Assert.NotNull(allProducts);
            Assert.AreEqual(2, allProducts.Count());
        }
        
        [TestCase("ProductTest1", "ProductTest1", 1)]
        [TestCase("ProductTest2", "ProductTest2", 2)]
        [TestCase("ProductTest3", "ProductTest3", 3)]
        public void ShouldGetProductByIdWithMoq(string productname, string expectedProductname, int expectedId)
        {
            var mock = new Mock<IRepository<Product>>();

            mock.Setup(s => s.GetById(expectedId)).Returns(new Product()
            { ProductName = productname, Id = expectedId });

            var repo = mock.Object;

            var productById = repo.GetById(expectedId);


            Assert.NotNull(productById);
            Assert.AreEqual(productById.ProductName, expectedProductname);
            Assert.AreEqual(productById.Id, expectedId);
        }

        [TestCase(1, true)]
        [TestCase(2, false)]
        [TestCase(3, true)]
        public void ShouldDeleteProductWithMoq(int id, bool expectedResult)
        {
            var mock = new Mock<IRepository<Product>>();

            mock.Setup(s => s.Delete(id)).Returns(expectedResult).Verifiable();

            var repo = mock.Object;

            var result = repo.Delete(id);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldUpdateProductWithMoq()
        {
            var productToBeUpdate = new Product() { Id = 1, ProductName = RandomUtil.GetRandomString("TestProduct") };
            var newProductname = RandomUtil.GetRandomString("ProductUpdate");
            var mock = new Mock<IRepository<Product>>();

            mock.Setup(s => s.Update(It.Is<Product>(t => t.ProductName.Contains("ProductUpdate")))).Callback<Product>((entity) =>
            {
                Assert.IsTrue(entity.ProductName.Contains("ProductUpdate"));
                Assert.AreEqual(entity.Id, productToBeUpdate.Id);

            }).Returns(() => new Product() { Id = productToBeUpdate.Id, ProductName = newProductname }).Verifiable();

            productToBeUpdate.ProductName = newProductname;
            
            var repository = mock.Object;
            var result = repository.Update(productToBeUpdate);

            Assert.IsTrue(result.ProductName.Contains("ProductUpdate"));
            Assert.AreEqual(productToBeUpdate.Id, result.Id);
        }
    }
}
