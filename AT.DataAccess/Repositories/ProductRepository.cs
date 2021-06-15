using System.Collections.Generic;
using System.Linq;
using AT.DataAccess.Data;
using AT.IDataAccess.IRepository;
using AT.Model.Common;

namespace AT.DataAccess.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ATDbContext _context;

        public ProductRepository(ATDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Where(w=> !w.IsDeleted).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(f=>f.Id==id && !f.IsDeleted);
        }

        public Product Create(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Product Update(Product entity)
        {
            var product = _context.Products.FirstOrDefault(f => f.Id == entity.Id && !f.IsDeleted);

            if (product == null) return null;

            product.IdProductType = entity.IdProductType;
            product.ProductName = entity.ProductName;
            

            _context.Products.Update(product);
            _context.SaveChanges();

            return product;
        }

        public bool Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
            if (product == null) return false;

            product.IsDeleted = true;
            _context.Products.Update(product);
            _context.SaveChanges();

            return true;
        }
    }
}
