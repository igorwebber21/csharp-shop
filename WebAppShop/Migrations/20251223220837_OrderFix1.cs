using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppShop.Migrations
{
    /// <inheritdoc />
    public partial class OrderFix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Order",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "id");
        }
    }
}
