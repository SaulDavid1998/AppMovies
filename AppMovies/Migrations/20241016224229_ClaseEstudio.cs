using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMovies.Migrations
{
    public partial class ClaseEstudio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEstudio",
                table: "Pelicula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    EstudioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.EstudioID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_IdEstudio",
                table: "Pelicula",
                column: "IdEstudio");

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Estudios_IdEstudio",
                table: "Pelicula",
                column: "IdEstudio",
                principalTable: "Estudios",
                principalColumn: "EstudioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Estudios_IdEstudio",
                table: "Pelicula");

            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropIndex(
                name: "IX_Pelicula_IdEstudio",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "IdEstudio",
                table: "Pelicula");
        }
    }
}
