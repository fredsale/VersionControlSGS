using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableSolicitud9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Supervisor_IdSupervisor",
                table: "Solicitud");

            migrationBuilder.AlterColumn<int>(
                name: "IdSupervisor",
                table: "Solicitud",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Supervisor_IdSupervisor",
                table: "Solicitud",
                column: "IdSupervisor",
                principalTable: "Supervisor",
                principalColumn: "IdSupervisor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Supervisor_IdSupervisor",
                table: "Solicitud");

            migrationBuilder.AlterColumn<int>(
                name: "IdSupervisor",
                table: "Solicitud",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Supervisor_IdSupervisor",
                table: "Solicitud",
                column: "IdSupervisor",
                principalTable: "Supervisor",
                principalColumn: "IdSupervisor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
