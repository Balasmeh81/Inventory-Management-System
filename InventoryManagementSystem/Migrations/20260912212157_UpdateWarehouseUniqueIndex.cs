using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWarehouseUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Warehouses_City_Id",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_Name",
                table: "Warehouses");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_City_Id_Name",
                table: "Warehouses",
                columns: new[] { "City_Id", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Warehouses_City_Id_Name",
                table: "Warehouses");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_City_Id",
                table: "Warehouses",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Name",
                table: "Warehouses",
                column: "Name",
                unique: true);
        }
    }
}
