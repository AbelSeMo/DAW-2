using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecoStation.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Detalle_DetalleId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_DetalleId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "DetalleId",
                table: "Producto");

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Cancelled",
                table: "Pedido",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Confirmed",
                table: "Pedido",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Delivered",
                table: "Pedido",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Paid",
                table: "Pedido",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Prepared",
                table: "Pedido",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Returned",
                table: "Pedido",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Detalle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_ProductoId",
                table: "Detalle",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Producto_ProductoId",
                table: "Detalle",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Producto_ProductoId",
                table: "Detalle");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_ProductoId",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Delivered",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Prepared",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Returned",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Detalle");

            migrationBuilder.AddColumn<int>(
                name: "DetalleId",
                table: "Producto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_DetalleId",
                table: "Producto",
                column: "DetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Detalle_DetalleId",
                table: "Producto",
                column: "DetalleId",
                principalTable: "Detalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
