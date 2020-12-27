using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftDeleteSample.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, false, 10m, "Title 1" },
                    { 2, false, 11m, "Title 2" },
                    { 3, false, 12m, "Title 3" },
                    { 4, false, 13m, "Title 4" },
                    { 5, false, 14m, "Title 5" },
                    { 6, false, 15m, "Title 6" },
                    { 7, false, 16m, "Title 7" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
