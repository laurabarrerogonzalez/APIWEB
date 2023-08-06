using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class OrdersFKIdCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
