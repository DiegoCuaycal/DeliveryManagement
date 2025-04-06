using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery_Management.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class v05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "VehiculoId",
                table: "Repartidor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "RepartidorId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Repartidor_VehiculoId",
                table: "Repartidor",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_RepartidorId",
                table: "Pedidos",
                column: "RepartidorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Repartidor_RepartidorId",
                table: "Pedidos",
                column: "RepartidorId",
                principalTable: "Repartidor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repartidor_Vehiculo_VehiculoId",
                table: "Repartidor",
                column: "VehiculoId",
                principalTable: "Vehiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Repartidor_RepartidorId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Repartidor_Vehiculo_VehiculoId",
                table: "Repartidor");

            migrationBuilder.DropIndex(
                name: "IX_Repartidor_VehiculoId",
                table: "Repartidor");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_RepartidorId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Repartidor");

            migrationBuilder.DropColumn(
                name: "RepartidorId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }
    }
}
