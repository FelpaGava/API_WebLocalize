using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Teste.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locais_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "EstadoID", "Nome", "Sigla" },
                values: new object[,]
                {
                    { 1, "Acre", "AC" },
                    { 2, "Alagoas", "AL" },
                    { 3, "Amapá", "AP" },
                    { 4, "Amazonas", "AM" },
                    { 5, "Bahia", "BA" },
                    { 6, "Ceará", "CE" },
                    { 7, "Distrito Federal", "DF" },
                    { 8, "Espírito Santo", "ES" },
                    { 9, "Goiás", "GO" },
                    { 10, "Maranhão", "MA" },
                    { 11, "Mato Grosso", "MT" },
                    { 12, "Mato Grosso do Sul", "MS" },
                    { 13, "Minas Gerais", "MG" },
                    { 14, "Pará", "PA" },
                    { 15, "Paraíba", "PB" },
                    { 16, "Paraná", "PR" },
                    { 17, "Pernambuco", "PE" },
                    { 18, "Piauí", "PI" },
                    { 19, "Rio de Janeiro", "RJ" },
                    { 20, "Rio Grande do Norte", "RN" },
                    { 21, "Rio Grande do Sul", "RS" },
                    { 22, "Rondônia", "RO" },
                    { 23, "Roraima", "RR" },
                    { 24, "Santa Catarina", "SC" },
                    { 25, "São Paulo", "SP" },
                    { 26, "Sergipe", "SE" },
                    { 27, "Tocantins", "TO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locais_EstadoId",
                table: "Locais",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
