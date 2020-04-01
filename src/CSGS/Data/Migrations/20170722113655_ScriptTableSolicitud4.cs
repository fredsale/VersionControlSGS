using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableSolicitud4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Supervisor_IdSupervisor",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_IdSupervisor",
                table: "Solicitud");
        }
    }
}
