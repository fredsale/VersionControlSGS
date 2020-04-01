using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableCursos9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaExt",
                columns: table => new
                {
                    IdCategoriaExt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCategoriaExt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaExt", x => x.IdCategoriaExt);
                });

            migrationBuilder.AddColumn<int>(
                name: "IdCategoriaExt",
                table: "CursoExt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CursoExt_IdCategoriaExt",
                table: "CursoExt",
                column: "IdCategoriaExt");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoExt_CategoriaExt_IdCategoriaExt",
                table: "CursoExt",
                column: "IdCategoriaExt",
                principalTable: "CategoriaExt",
                principalColumn: "IdCategoriaExt",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoExt_CategoriaExt_IdCategoriaExt",
                table: "CursoExt");

            migrationBuilder.DropIndex(
                name: "IX_CursoExt_IdCategoriaExt",
                table: "CursoExt");

            migrationBuilder.DropColumn(
                name: "IdCategoriaExt",
                table: "CursoExt");

            migrationBuilder.DropTable(
                name: "CategoriaExt");
        }
    }
}
