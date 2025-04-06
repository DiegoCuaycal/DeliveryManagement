using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery_Management.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class v078 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Restaurantees_RestauranteId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Repartidor_Vehiculo_VehiculoId",
                table: "Repartidor");

            migrationBuilder.DropTable(
                name: "Restaurantees");

            migrationBuilder.DropIndex(
                name: "IX_Repartidor_VehiculoId",
                table: "Repartidor");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Repartidor");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Pedidos",
                newName: "ZonaId");

            migrationBuilder.RenameColumn(
                name: "RestauranteId",
                table: "Pedidos",
                newName: "DetallePedidoId");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Pedidos",
                newName: "DireccionDestino");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_RestauranteId",
                table: "Pedidos",
                newName: "IX_Pedidos_DetallePedidoId");

            migrationBuilder.AddColumn<int>(
                name: "CapacidadCarga",
                table: "Vehiculo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Vehiculo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Repartidor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Repartidor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoLicencia",
                table: "Repartidor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Peso",
                table: "Pedidos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidoRepartidor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destinatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    DireccionDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZonaDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetalleDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetallePrecio = table.Column<float>(type: "real", nullable: false),
                    RepartidorNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepartidorApellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoRepartidor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoRepartidor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepartidorId = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoRepartidor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiculoRepartidor_Repartidor_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Repartidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiculoRepartidor_Vehiculo_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ZonaId",
                table: "Pedidos",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoRepartidor_RepartidorId",
                table: "VehiculoRepartidor",
                column: "RepartidorId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoRepartidor_VehiculoId",
                table: "VehiculoRepartidor",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_DetallePedido_DetallePedidoId",
                table: "Pedidos",
                column: "DetallePedidoId",
                principalTable: "DetallePedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Zona_ZonaId",
                table: "Pedidos",
                column: "ZonaId",
                principalTable: "Zona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_DetallePedido_DetallePedidoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Zona_ZonaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "PedidoRepartidor");

            migrationBuilder.DropTable(
                name: "VehiculoRepartidor");

            migrationBuilder.DropTable(
                name: "Zona");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ZonaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CapacidadCarga",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Repartidor");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Repartidor");

            migrationBuilder.DropColumn(
                name: "TipoLicencia",
                table: "Repartidor");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "ZonaId",
                table: "Pedidos",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "DireccionDestino",
                table: "Pedidos",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "DetallePedidoId",
                table: "Pedidos",
                newName: "RestauranteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_DetallePedidoId",
                table: "Pedidos",
                newName: "IX_Pedidos_RestauranteId");

            migrationBuilder.AddColumn<int>(
                name: "VehiculoId",
                table: "Repartidor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Restaurantees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repartidor_VehiculoId",
                table: "Repartidor",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Restaurantees_RestauranteId",
                table: "Pedidos",
                column: "RestauranteId",
                principalTable: "Restaurantees",
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
    }
}
