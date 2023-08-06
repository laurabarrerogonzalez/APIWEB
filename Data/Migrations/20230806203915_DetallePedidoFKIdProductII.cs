using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DetallePedidoFKIdProductII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersIdOrder",
                table: "Detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_OrdersIdOrder",
                table: "Detalle",
                column: "OrdersIdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Orders_OrdersIdOrder",
                table: "Detalle",
                column: "OrdersIdOrder",
                principalTable: "Orders",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Orders_OrdersIdOrder",
                table: "Detalle");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_OrdersIdOrder",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "OrdersIdOrder",
                table: "Detalle");
        }
    }
}
