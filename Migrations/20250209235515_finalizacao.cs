using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Teste.Migrations
{
    /// <inheritdoc />
    public partial class finalizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 1,
                column: "CidadeID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 2,
                column: "CidadeID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 3,
                column: "CidadeID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 4,
                column: "CidadeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 5,
                column: "CidadeID",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 1,
                column: "CidadeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 2,
                column: "CidadeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 3,
                column: "CidadeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 4,
                column: "CidadeID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 5,
                column: "CidadeID",
                value: 2);
        }
    }
}
