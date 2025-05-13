using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedAgenda.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoUsuarioPacienteMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Usuarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Usuarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MedicoId",
                table: "Usuarios",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PacienteId",
                table: "Usuarios",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Medicos_MedicoId",
                table: "Usuarios",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Pacientes_PacienteId",
                table: "Usuarios",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Medicos_MedicoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Pacientes_PacienteId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MedicoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PacienteId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Usuarios");
        }
    }
}
