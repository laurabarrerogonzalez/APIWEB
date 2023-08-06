using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DetallePedidoFKIdProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductsIdProduct",
                table: "Detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_ProductsIdProduct",
                table: "Detalle",
                column: "ProductsIdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Products_ProductsIdProduct",
                table: "Detalle",
                column: "ProductsIdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Products_ProductsIdProduct",
                table: "Detalle");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_ProductsIdProduct",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "ProductsIdProduct",
                table: "Detalle");
        }
    }
}
