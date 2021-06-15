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
    public class UserRepositoryInMemoryTest
    {
        private IConfigurationRoot _config;
        private ATDbContext _context;

        [SetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var options = new DbContextOptionsBuilder<ATDbContext>().UseInMemoryDatabase(databaseName:"ATWebApi").Options;

            _context = new ATDbContext(options, _config);
        }

        [TestCase("Juan Perez", "Juan Perez")]
        public void ShouldCreateNewUserInMemory(string username, string expectedUsername)
        {
            var userTobeCreate = new User{Id = 0, UserName = username};
            
            IRepository<User> useRepository = new UserRepository(_context);
            var createduser = useRepository.Create(userTobeCreate);

            Assert.AreEqual(createduser.UserName, expectedUsername);
            Assert.Greater(createduser.Id,0);
        }

        [Test]
        public void ShouldGetUserByIdInMemory()
        {
            var userTobeCreate = new User{Id = 0, UserName = RandomUtil.GetRandomString("UserTest") };

            IRepository <User> useRepository = new UserRepository(_context);
            var createduser = useRepository.Create(userTobeCreate);

            var userById = useRepository.GetById(createduser.Id);

            Assert.NotNull(userById);
            Assert.Greater(userById.Id,0);
        }

        [Test]
        public void ShouldGetAllUsersInMemory()
        {
            var userTobeCreate = new User { Id = 0, UserName = RandomUtil.GetRandomString("UserTest") };

            IRepository<User> useRepository = new UserRepository(_context);
            useRepository.Create(userTobeCreate);

            var allUsers = useRepository.GetAll();

            Assert.NotNull(allUsers);
            Assert.True(allUsers.Any());
        }


        [Test]
        public void ShouldDeleteUserInMemory()
        {
            var userTobeCreate = new User { Id = 0, UserName = RandomUtil.GetRandomString("UserTest") };

            IRepository<User> useRepository = new UserRepository(_context);
            var userToDelete = useRepository.Create(userTobeCreate);

            var userIsDeleted = useRepository.Delete(userToDelete.Id);

            Assert.True(userIsDeleted);
        }


        [Test]
        public void ShouldUpdateUserInMemory()
        {
            var userTobeCreate = new User { Id = 0, UserName = RandomUtil.GetRandomString("UserTest") };

            IRepository<User> useRepository = new UserRepository(_context);
            var userToBeUpdate = useRepository.Create(userTobeCreate);

            userToBeUpdate.UserName = RandomUtil.GetRandomString("UserToUpdate");

            var userUpdated = useRepository.Update(userToBeUpdate);

            Assert.NotNull(userUpdated);
            Assert.IsNotEmpty(userUpdated.UserName);
            Assert.That(userUpdated.UserName.Contains("UserToUpdate"));
            Assert.Greater(userUpdated.Id, 0);
        }
    }
}
