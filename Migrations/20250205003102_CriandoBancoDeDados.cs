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
                name: "Cidades",
                columns: table => new
                {
                    CidadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.CidadeID);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estados",
                        principalColumn: "EstadoID");
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
                    CidadeID = table.Column<int>(type: "int", nullable: true),
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locais_Cidades_CidadeID",
                        column: x => x.CidadeID,
                        principalTable: "Cidades",
                        principalColumn: "CidadeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locais_Estados_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estados",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "CidadeID", "EstadoID", "Nome" },
                values: new object[,]
                {
                    { 1, 25, "Tupã" },
                    { 2, 25, "Marília" },
                    { 3, 25, "Vera Cruz" },
                    { 4, 25, "Pompeia" },
                    { 5, 25, "Ocauçu" },
                    { 6, 25, "Júlio Mesquita" },
                    { 7, 25, "Lupércio" },
                    { 8, 25, "Alvinlândia" },
                    { 9, 25, "Guaimbê" },
                    { 10, 25, "Echaporã" },
                    { 11, 25, "Oscar Bressane" },
                    { 12, 25, "Queiroz" },
                    { 13, 25, "Borá" },
                    { 14, 25, "Cândido Mota" },
                    { 15, 25, "Paraguaçu Paulista" },
                    { 16, 5, "Salvador" },
                    { 17, 5, "Feira de Santana" },
                    { 18, 5, "Vitória da Conquista" },
                    { 19, 5, "Camaçari" },
                    { 20, 5, "Itabuna" },
                    { 21, 13, "Belo Horizonte" },
                    { 22, 13, "Uberlândia" },
                    { 23, 13, "Contagem" },
                    { 24, 13, "Juiz de Fora" },
                    { 25, 13, "Betim" },
                    { 26, 16, "Curitiba" },
                    { 27, 16, "Londrina" },
                    { 28, 16, "Maringá" },
                    { 29, 16, "Ponta Grossa" },
                    { 30, 16, "Cascavel" },
                    { 31, 21, "Porto Alegre" },
                    { 32, 21, "Caxias do Sul" },
                    { 33, 21, "Pelotas" },
                    { 34, 21, "Santa Maria" },
                    { 35, 21, "Canoas" },
                    { 36, 6, "Fortaleza" },
                    { 37, 6, "Caucaia" },
                    { 38, 6, "Juazeiro do Norte" },
                    { 39, 6, "Maracanaú" },
                    { 40, 6, "Sobral" },
                    { 41, 17, "Recife" },
                    { 42, 17, "Jaboatão dos Guararapes" },
                    { 43, 17, "Olinda" },
                    { 44, 17, "Caruaru" },
                    { 45, 17, "Petrolina" }
                });

            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "CidadeID", "Descricao", "Endereco", "EstadoID", "Nome" },
                values: new object[,]
                {
                    { 1, 1, "Igreja histórica com bela arquitetura", "Praça Dr. Nemezio V. Souza, 50 - Centro, Marília - SP", 25, "Basílica de São Bento" },
                    { 2, 1, "Área verde para caminhadas e lazer", "Av. República, 1500 - Bosque, Marília - SP", 25, "Bosque Municipal" },
                    { 3, 1, "Museu com fósseis e exposições históricas", "Rua São Paulo, 255 - Centro, Marília - SP", 25, "Museu de Paleontologia" },
                    { 4, 2, "Ótimo para caminhadas e lazer ao ar livre", "Rua Comendador José G. dos Santos, s/n - Centro, Tupã - SP", 25, "Parque do Povo" },
                    { 5, 2, "Centro cultural com exposições sobre a história indígena", "Rua Tupi, 1825 - Centro, Tupã - SP", 25, "Museu Índia Vanuíre" },
                    { 6, 16, "Centro histórico de Salvador", "Praça Terreiro de Jesus, s/n - Pelourinho, Salvador - BA", 5, "Pelourinho" },
                    { 7, 16, "Um dos cartões postais da Bahia", "Avenida Oceanica, s/n - Barra, Salvador - BA", 5, "Farol da Barra" },
                    { 8, 17, "Destino turístico famoso na Bahia", "Rua do Farol, 100 - Praia do Forte, Mata de São João - BA", 5, "Praia do Forte" },
                    { 9, 21, "Ponto histórico e cultural", "Praça da Liberdade, s/n - Liberdade, Belo Horizonte - MG", 13, "Praça da Liberdade" },
                    { 10, 22, "Cidade histórica famosa", "Praça Tiradentes, s/n - Centro, Ouro Preto - MG", 13, "Ouro Preto" },
                    { 11, 26, "Um dos principais pontos turísticos de Curitiba", "Rua Engenheiro Ostoja Roguski, 100 - Jardim Botânico, Curitiba - PR", 16, "Jardim Botânico" },
                    { 12, 26, "Teatro em meio à natureza", "Avenida João Gualberto, 550 - Abranches, Curitiba - PR", 16, "Ópera de Arame" },
                    { 13, 31, "Ótimo para lazer e piqueniques", "Parque da Redenção, s/n - Farroupilha, Porto Alegre - RS", 21, "Parque da Redenção" },
                    { 14, 32, "Cidade turística com forte influência europeia", "Rua São Pedro, 225 - Centro, Gramado - RS", 21, "Gramado" },
                    { 15, 36, "Uma das praias mais bonitas do Brasil", "Rua do Forró, s/n - Jericoacoara, Jericoacoara - CE", 6, "Praia de Jericoacoara" },
                    { 16, 36, "Ponto turístico famoso", "Avenida Beira Mar, s/n - Meireles, Fortaleza - CE", 6, "Beira Mar de Fortaleza" },
                    { 17, 41, "Praia paradisíaca", "Rua Beira Mar, s/n - Porto de Galinhas, Ipojuca - PE", 17, "Porto de Galinhas" },
                    { 18, 41, "Local histórico no Recife Antigo", "Praça do Marco Zero, s/n - Recife Antigo, Recife - PE", 17, "Marco Zero" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoID",
                table: "Cidades",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Locais_CidadeID",
                table: "Locais",
                column: "CidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Locais_EstadoID",
                table: "Locais",
                column: "EstadoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
