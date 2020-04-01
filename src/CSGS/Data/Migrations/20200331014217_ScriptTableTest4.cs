using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableTest4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IdCurso",
                table: "Matricula",
                column: "IdCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Curso_IdCurso",
                table: "Matricula",
                column: "IdCurso",
                principalTable: "Curso",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Curso_IdCurso",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_IdCurso",
                table: "Matricula");
        }
    }
}
