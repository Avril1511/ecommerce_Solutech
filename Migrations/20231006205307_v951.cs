using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce_Solutech.Migrations
{
    /// <inheritdoc />
    public partial class v951 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Endereco_IdEndereco",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_IdEndereco",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "HashSenha",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "login",
                table: "cliente");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Endereco",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Endereco");

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HashSenha",
                table: "cliente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "login",
                table: "cliente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdEndereco",
                table: "Endereco",
                column: "IdEndereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Endereco_IdEndereco",
                table: "Endereco",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
