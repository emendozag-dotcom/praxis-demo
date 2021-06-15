using AT.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT.DataAccess.DataSeed
{
    public class ProductTypeSeed : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData(
                new ProductType {ProductTypeName = "Type 1", Id = 1},
                new ProductType {ProductTypeName = "Type 2", Id = 2},
                new ProductType {ProductTypeName = "Type 3", Id = 3},
                new ProductType {ProductTypeName = "Type 4", Id = 4});
        }
    }
}
