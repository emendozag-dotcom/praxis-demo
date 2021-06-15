using AT.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT.DataAccess.DataSeed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { ProductName = "Product 1", Id = 1, IdProductType = 1 },
                new Product { ProductName = "Product 2", Id = 2, IdProductType = 2 },
                new Product { ProductName = "Product 3", Id = 3, IdProductType = 3 },
                new Product { ProductName = "Product 4", Id = 4, IdProductType = 4 },
                new Product { ProductName = "Product 5", Id = 5, IdProductType = 2 },
                new Product { ProductName = "Product 6", Id = 6, IdProductType = 1 }
                
                );
        }
    }
}
