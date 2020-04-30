using Microsoft.EntityFrameworkCore.Migrations;

namespace SysWas.Repository.Migrations
{
    public partial class EmpresaF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "Id", "Bairro", "Cep", "Complemento", "Localidade", "Logradouro", "Uf" },
                values: new object[] { 1, "N/D", "00000-000", "N/D", "N/D", "N/D", "N/D" });

            migrationBuilder.InsertData(
                table: "TipoFornecedor",
                columns: new[] { "Id", "Insumo", "Madeira", "Tipo" },
                values: new object[,]
                {
                    { 1, false, true, "Madeira" },
                    { 2, true, false, "Insumo" },
                    { 4, false, false, "Serviços" },
                    { 5, false, false, "Outros" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Endereco",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoFornecedor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoFornecedor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoFornecedor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoFornecedor",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
