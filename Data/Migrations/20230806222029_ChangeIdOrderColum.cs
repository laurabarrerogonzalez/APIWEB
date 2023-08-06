using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdOrderColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerIdCustomer",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerIdCustomer",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerIdCustomer",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemIdOrder",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderItemIdOrder",
                table: "Products",
                column: "OrderItemIdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderItemIdOrder",
                table: "Products",
                column: "OrderItemIdOrder",
                principalTable: "Orders",
                principalColumn: "IdOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderItemIdOrder",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderItemIdOrder",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderItemIdOrder",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CustomerIdCustomer",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerIdCustomer",
                table: "Orders",
                column: "CustomerIdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerIdCustomer",
                table: "Orders",
                column: "CustomerIdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
