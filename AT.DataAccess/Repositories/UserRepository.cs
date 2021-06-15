using System.Collections.Generic;
using System.Linq;
using AT.DataAccess.Data;
using AT.IDataAccess.IRepository;
using AT.Model.Common;

namespace AT.DataAccess.Repositories {
    public class UserRepository : IRepository<User> {
        private readonly ATDbContext context;
        public UserRepository (ATDbContext context) {
            this.context = context;

        }


        public IEnumerable<User> GetAll()
        {
            return context.Users.Where(w => !w.IsDeleted).ToList();
        }

        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
        }

        public User Create(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public User Update(User entity)
        {
            var user = context.Users.FirstOrDefault(f => f.Id == entity.Id && !f.IsDeleted);
            if (user == null) return null;

            user.UserName = entity.UserName;

            context.Users.Update(user);
            context.SaveChanges();

            return user;

        }

        public bool Delete (int id)
        {
            var user = context.Users.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
            if (user == null) return false;

            user.IsDeleted = true;
            context.Users.Update(user);
            context.SaveChanges();

            return true;

        }

    }
}