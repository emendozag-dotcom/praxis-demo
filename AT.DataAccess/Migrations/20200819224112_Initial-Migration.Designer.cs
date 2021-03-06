// <auto-generated />
using AT.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AT.DataAccess.Migrations
{
    [DbContext(typeof(ATDbContext))]
    [Migration("20200819224112_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AT.Model.Common.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProductType")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdProductType");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdProductType = 1,
                            ProductName = "Product 1"
                        },
                        new
                        {
                            Id = 2,
                            IdProductType = 2,
                            ProductName = "Product 2"
                        },
                        new
                        {
                            Id = 3,
                            IdProductType = 3,
                            ProductName = "Product 3"
                        },
                        new
                        {
                            Id = 4,
                            IdProductType = 4,
                            ProductName = "Product 4"
                        },
                        new
                        {
                            Id = 5,
                            IdProductType = 2,
                            ProductName = "Product 5"
                        },
                        new
                        {
                            Id = 6,
                            IdProductType = 1,
                            ProductName = "Product 6"
                        });
                });

            modelBuilder.Entity("AT.Model.Common.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductTypeName = "Type 1"
                        },
                        new
                        {
                            Id = 2,
                            ProductTypeName = "Type 2"
                        },
                        new
                        {
                            Id = 3,
                            ProductTypeName = "Type 3"
                        },
                        new
                        {
                            Id = 4,
                            ProductTypeName = "Type 4"
                        });
                });

            modelBuilder.Entity("AT.Model.Common.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            UserName = "Usuario 1"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            UserName = "Usuario 2"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            UserName = "Usuario 3"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            UserName = "Usuario 4"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            UserName = "Usuario 5"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            UserName = "Usuario 6"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            UserName = "Usuario 7"
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            UserName = "Usuario 8"
                        });
                });

            modelBuilder.Entity("AT.Model.Common.Product", b =>
                {
                    b.HasOne("AT.Model.Common.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("IdProductType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
