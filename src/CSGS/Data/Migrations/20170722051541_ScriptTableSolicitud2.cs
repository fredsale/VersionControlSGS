using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableSolicitud2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motivo",
                columns: table => new
                {
                    IdMotivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreMotivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivo", x => x.IdMotivo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_IdMotivo",
                table: "Solicitud",
                column: "IdMotivo");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Motivo_IdMotivo",
                table: "Solicitud",
                column: "IdMotivo",
                principalTable: "Motivo",
                principalColumn: "IdMotivo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Motivo_IdMotivo",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_IdMotivo",
                table: "Solicitud");

            migrationBuilder.DropTable(
                name: "Motivo");
        }
    }
}
