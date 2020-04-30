using Microsoft.EntityFrameworkCore.Migrations;

namespace SysWas.Repository.Migrations
{
    public partial class StepTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Endereco_EnderecoId",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EnderecoCep",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "EnderecoCep",
                table: "Empresa");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Empresa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Endereco_EnderecoId",
                table: "Empresa",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Endereco_EnderecoId",
                table: "Empresa");

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCep",
                table: "Fornecedor",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Empresa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCep",
                table: "Empresa",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Endereco_EnderecoId",
                table: "Empresa",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
