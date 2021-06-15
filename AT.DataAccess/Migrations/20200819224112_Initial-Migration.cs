using Microsoft.EntityFrameworkCore.Migrations;

namespace AT.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    IdProductType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_IdProductType",
                        column: x => x.IdProductType,
                        principalSchema: "dbo",
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ProductTypes",
                columns: new[] { "Id", "ProductTypeName" },
                values: new object[,]
                {
                    { 1, "Type 1" },
                    { 2, "Type 2" },
                    { 3, "Type 3" },
                    { 4, "Type 4" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "IsDeleted", "UserName" },
                values: new object[,]
                {
                    { 1, false, "Usuario 1" },
                    { 2, false, "Usuario 2" },
                    { 3, false, "Usuario 3" },
                    { 4, false, "Usuario 4" },
                    { 5, false, "Usuario 5" },
                    { 6, false, "Usuario 6" },
                    { 7, false, "Usuario 7" },
                    { 8, false, "Usuario 8" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "IdProductType", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "Product 1" },
                    { 6, 1, "Product 6" },
                    { 2, 2, "Product 2" },
                    { 5, 2, "Product 5" },
                    { 3, 3, "Product 3" },
                    { 4, 4, "Product 4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProductType",
                schema: "dbo",
                table: "Products",
                column: "IdProductType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "dbo");
        }
    }
}
