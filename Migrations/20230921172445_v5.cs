using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce_Solutech.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliente_Endereco_IdEndereco",
                table: "cliente");

            migrationBuilder.AlterColumn<int>(
                name: "IdEndereco",
                table: "cliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_Endereco_IdEndereco",
                table: "cliente",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliente_Endereco_IdEndereco",
                table: "cliente");

            migrationBuilder.AlterColumn<int>(
                name: "IdEndereco",
                table: "cliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_Endereco_IdEndereco",
                table: "cliente",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
