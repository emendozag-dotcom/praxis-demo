using System.Collections.Generic;
using System.Linq;
using AT.DataAccess.Data;
using AT.IDataAccess.IRepository;
using AT.Model.Common;

namespace AT.DataAccess.Repositories
{
    public class ProductTypeRepository : IRepository<ProductType>
    {
        private readonly ATDbContext _context;

        public ProductTypeRepository(ATDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProductType> GetAll()
        {
            return _context.ProductTypes.Where(w => !w.IsDeleted).ToList();
        }

        public ProductType GetById(int id)
        {
            return _context.ProductTypes.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
        }

        public ProductType Create(ProductType entity)
        {
            _context.ProductTypes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public ProductType Update(ProductType entity)
        {
            var productType = _context.ProductTypes.FirstOrDefault(f => f.Id == entity.Id && !f.IsDeleted);

            if (productType == null) return null;

            productType.ProductTypeName = entity.ProductTypeName;

            _context.ProductTypes.Update(productType);
            _context.SaveChanges();

            return productType;
        }

        public bool Delete(int id)
        {
            var productType = _context.ProductTypes.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
            if (productType == null) return false;
            
            productType.IsDeleted = true;
            
            _context.ProductTypes.Update(productType);
            _context.SaveChanges();
            
            return true;
        }
    }
}
