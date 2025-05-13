using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedAgenda.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeId",
                table: "Consultas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_EspecialidadeId",
                table: "Consultas",
                column: "EspecialidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Especialidades_EspecialidadeId",
                table: "Consultas",
                column: "EspecialidadeId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Especialidades_EspecialidadeId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_EspecialidadeId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EspecialidadeId",
                table: "Consultas");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
