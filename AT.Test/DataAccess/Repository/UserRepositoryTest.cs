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
    [TestFixture]
    public class UserRepositoryTest
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
        [Test]
        public void ShouldGetAllUsers()
        {
            IRepository<User> userRepo = new UserRepository(_context);

            var userList = userRepo.GetAll();

            Assert.Greater(userList.Count(), 0);
        }

        [Test]
        public void ShouldGetUserById()
        {
            var userTobeCreate = new User { Id = 0, UserName = RandomUtil.GetRandomString("TestUser") };

            IRepository<User> userRepository = new UserRepository(_context);
            var createduser = userRepository.Create(userTobeCreate);

            var userFetched = userRepository.GetById(createduser.Id);

            Assert.NotNull(userFetched);
            Assert.Greater(userFetched.Id, 0);
        }

        [Test]
        public void ShouldCreateUser()
        {
            var userTobeCreate = new User { UserName = RandomUtil.GetRandomString("TestUser") };

            IRepository<User> userRepository = new UserRepository(_context);
            var createduser = userRepository.Create(userTobeCreate);

            Assert.NotNull(createduser);
            Assert.IsNotEmpty(createduser.UserName);
            Assert.Greater(createduser.Id, 0);
        }



        [Test]
        public void ShouldDeleteUser()
        {
            var userTobeCreate = new User { Id = 0, UserName = RandomUtil.GetRandomString("TestUser") };

            IRepository<User> userRepository = new UserRepository(_context);
            var createduser = userRepository.Create(userTobeCreate);

            var userIsDeleted = userRepository.Delete(createduser.Id);

            Assert.True(userIsDeleted);
        }

        [Test]
        public void ShouldUpdateUser()
        {
            var userTobeCreate = new User { Id = 0, UserName = RandomUtil.GetRandomString("TestUser") };

            IRepository<User> userRepository = new UserRepository(_context);
            var userToBeUpdate = userRepository.Create(userTobeCreate);

            userToBeUpdate.UserName = RandomUtil.GetRandomString("UserToUpdate");

            var userUpdated = userRepository.Update(userToBeUpdate);

            Assert.NotNull(userUpdated);
            Assert.IsNotEmpty(userUpdated.UserName);
            Assert.That(userUpdated.UserName.Contains("UserToUpdate"));
            Assert.Greater(userUpdated.Id, 0);
        }
    }
}
