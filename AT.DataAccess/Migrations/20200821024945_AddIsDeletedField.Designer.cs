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
    [Migration("20200821024945_AddIsDeletedField")]
    partial class AddIsDeletedField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AT.Model.Common.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AT.Model.Common.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProductType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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
                            IsDeleted = false,
                            ProductName = "Product 1"
                        },
                        new
                        {
                            Id = 2,
                            IdProductType = 2,
                            IsDeleted = false,
                            ProductName = "Product 2"
                        },
                        new
                        {
                            Id = 3,
                            IdProductType = 3,
                            IsDeleted = false,
                            ProductName = "Product 3"
                        },
                        new
                        {
                            Id = 4,
                            IdProductType = 4,
                            IsDeleted = false,
                            ProductName = "Product 4"
                        },
                        new
                        {
                            Id = 5,
                            IdProductType = 2,
                            IsDeleted = false,
                            ProductName = "Product 5"
                        },
                        new
                        {
                            Id = 6,
                            IdProductType = 1,
                            IsDeleted = false,
                            ProductName = "Product 6"
                        });
                });

            modelBuilder.Entity("AT.Model.Common.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ProductTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            ProductTypeName = "Type 1"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            ProductTypeName = "Type 2"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            ProductTypeName = "Type 3"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            ProductTypeName = "Type 4"
                        });
                });

            modelBuilder.Entity("AT.Model.Common.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("AT.Model.Common.ProjectEmployee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectEmployees");
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

            modelBuilder.Entity("AT.Model.Common.ProjectEmployee", b =>
                {
                    b.HasOne("AT.Model.Common.Employee", "Employee")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AT.Model.Common.Project", "Project")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
