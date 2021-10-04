using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTO.API.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdemDeServico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroOrdemDeServico = table.Column<long>(type: "bigint", nullable: false),
                    TituloServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnpjCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfPrestadorServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomePrestadorServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataExecucaoServico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemDeServico", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemDeServico");
        }
    }
}
