using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecoStation.Migrations
{
    /// <inheritdoc />
    public partial class ModelosCambiados3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriceChain",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceChain",
                table: "Producto");
        }
    }
}
