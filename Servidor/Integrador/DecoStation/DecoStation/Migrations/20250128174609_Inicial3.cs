using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecoStation.Migrations
{
    /// <inheritdoc />
    public partial class Inicial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_CategoryId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Imagen_ImageId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_CategoryId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Producto",
                newName: "CategoriaID");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_ImageId",
                table: "Producto",
                newName: "IX_Producto_CategoriaID");

            migrationBuilder.AddColumn<bool>(
                name: "Escaparate",
                table: "Producto",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_CategoriaID",
                table: "Producto",
                column: "CategoriaID",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_CategoriaID",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Escaparate",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "CategoriaID",
                table: "Producto",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_CategoriaID",
                table: "Producto",
                newName: "IX_Producto_ImageId");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoryId",
                table: "Producto",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_CategoryId",
                table: "Producto",
                column: "CategoryId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Imagen_ImageId",
                table: "Producto",
                column: "ImageId",
                principalTable: "Imagen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
