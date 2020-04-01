using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableCursos7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prueba3",
                columns: table => new
                {
                    IdPrueba3 = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombrePrueba3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prueba3", x => x.IdPrueba3);
                });

            migrationBuilder.AddColumn<int>(
                name: "IdPrueba3",
                table: "Prueba2",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prueba2_IdPrueba3",
                table: "Prueba2",
                column: "IdPrueba3");

            migrationBuilder.AddForeignKey(
                name: "FK_Prueba2_Prueba3_IdPrueba3",
                table: "Prueba2",
                column: "IdPrueba3",
                principalTable: "Prueba3",
                principalColumn: "IdPrueba3",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prueba2_Prueba3_IdPrueba3",
                table: "Prueba2");

            migrationBuilder.DropIndex(
                name: "IX_Prueba2_IdPrueba3",
                table: "Prueba2");

            migrationBuilder.DropColumn(
                name: "IdPrueba3",
                table: "Prueba2");

            migrationBuilder.DropTable(
                name: "Prueba3");
        }
    }
}
