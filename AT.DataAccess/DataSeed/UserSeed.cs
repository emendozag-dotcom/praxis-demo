using AT.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT.DataAccess.DataSeed
{
   public class UserSeed: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, IsDeleted = false, UserName = "Usuario 1"},
                new User { Id = 2, IsDeleted = false, UserName = "Usuario 2"},
                new User { Id = 3, IsDeleted = false, UserName = "Usuario 3"},
                new User { Id = 4, IsDeleted = false, UserName = "Usuario 4"},
                new User { Id = 5, IsDeleted = false, UserName = "Usuario 5"},
                new User { Id = 6, IsDeleted = false, UserName = "Usuario 6"},
                new User { Id = 7, IsDeleted = false, UserName = "Usuario 7"},
                new User { Id = 8, IsDeleted = false, UserName = "Usuario 8"}

            );
        }
    }
}
