using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedAgenda.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class MudancaDeNomeDePropriedade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "Senha");
        }
    }
}
