using AT.DataAccess.Data;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using AT.Test.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AT.Test.DataAccess.Repository
{
    [TestFixture]
    public class UserRepositoryMock
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

        [TestCase("Juan Perez","Juan Perez",10)]
        [TestCase("Marcelo Gomez", "Marcelo Gomez", 10)]
        [TestCase("Rodrigo Hau", "Rodrigo Hau", 10)]
        public void ShouldCallCreateUserWithMoq(string username, string expectedUsername, int expectedId)
        {
            var userToBeCreated = new User {UserName = username};
            var mock = new Mock<IRepository<User>>();
            mock.Setup(p => p.Create(userToBeCreated)).Returns(new User {UserName = username, Id = expectedId});

            var repo = mock.Object;
            var createdUser = repo.Create(userToBeCreated);

            Assert.AreEqual(createdUser.UserName, expectedUsername);
            Assert.AreEqual(createdUser.Id, expectedId);
        }


        [Test]
        public void ShouldGetAllUsersWithMoq()
        {
            var mock = new Mock<IRepository<User>>();

            mock.Setup(s => s.GetAll()).Returns(new List<User> { new User { Id=1, UserName= RandomUtil.GetRandomString("TestUser")}, new User { Id = 1, UserName = RandomUtil.GetRandomString("TestUser") } }).Verifiable();

            var repo = mock.Object;

            var allUsers = repo.GetAll();


            Assert.NotNull(allUsers);
            Assert.AreEqual(2, allUsers.Count());
        }

        [TestCase("Jhon Math", "Jhon Math", 10)]
        [TestCase("Andrew Thomas", "Andrew Thomas", 11)]
        [TestCase("Anderson Marshmall", "Anderson Marshmall", 12)]
        public void ShouldGetUserByIdWithMoq(string username, string expectedUsername, int expectedId)
        {
            var mock = new Mock<IRepository<User>>();

            mock.Setup(s => s.GetById(expectedId)).Returns(new User()
                {UserName = username, Id = expectedId});

            var repo = mock.Object;

            var userById = repo.GetById(expectedId);


            Assert.NotNull(userById);
            Assert.AreEqual(userById.UserName, expectedUsername);
            Assert.AreEqual(userById.Id, expectedId);
        }

        [TestCase(1,true)]
        [TestCase(2,false)]
        [TestCase(3,true)]
        public void ShouldDeleteUserWithMoq(int id,bool expectedResult)
        {
            var mock = new Mock<IRepository<User>>();

            mock.Setup(s => s.Delete(id)).Returns(expectedResult).Verifiable();

            var repo = mock.Object;

            var result = repo.Delete(id);

            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void ShouldUpdateUserWithMoq()
        {
            var userToBeUpdate = new User(){Id = 1, UserName = RandomUtil.GetRandomString("TestUser")};
            var newUsername = RandomUtil.GetRandomString("UserUpdate");
            var mock = new Mock<IRepository<User>>();

            mock.Setup(s => s.Update(It.Is<User>(t=>t.UserName.Contains("UserUpdate")))).Callback<User>((entity) =>
            {
                Assert.IsTrue(entity.UserName.Contains("UserUpdate"));
                Assert.AreEqual(entity.Id, userToBeUpdate.Id);

            }).Returns(() => new User() {Id = userToBeUpdate.Id, UserName = newUsername }).Verifiable();

            var repo = mock.Object;

            userToBeUpdate.UserName = newUsername;
            var result = repo.Update(userToBeUpdate);

            Assert.IsTrue(result.UserName.Contains("UserUpdate"));
            Assert.AreEqual(userToBeUpdate.Id, result.Id);
        }

    }
}
