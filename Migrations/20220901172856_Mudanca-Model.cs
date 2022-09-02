using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteSinqia.Migrations
{
    public partial class MudancaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "PontoTuristicoModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "PontoTuristicoModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "PontoTuristicoModels");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "PontoTuristicoModels");
        }
    }
}
