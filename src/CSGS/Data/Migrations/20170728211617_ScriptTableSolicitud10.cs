using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableSolicitud10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Supervisor_IdSupervisor",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_IdSupervisor",
                table: "Solicitud");

            migrationBuilder.DropTable(
                name: "Supervisor");

            migrationBuilder.AlterColumn<string>(
                name: "IdSupervisor",
                table: "Solicitud",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supervisor",
                columns: table => new
                {
                    IdSupervisor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreSupervisor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisor", x => x.IdSupervisor);
                });

            migrationBuilder.AlterColumn<int>(
                name: "IdSupervisor",
                table: "Solicitud",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_IdSupervisor",
                table: "Solicitud",
                column: "IdSupervisor");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Supervisor_IdSupervisor",
                table: "Solicitud",
                column: "IdSupervisor",
                principalTable: "Supervisor",
                principalColumn: "IdSupervisor",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
