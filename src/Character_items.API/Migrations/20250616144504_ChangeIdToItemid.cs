using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pazio_test2.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdToItemid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Item",
                newName: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Item",
                newName: "Id");
        }
    }
}
