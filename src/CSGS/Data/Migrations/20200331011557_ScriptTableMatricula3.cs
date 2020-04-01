using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableMatricula3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Cursos_CursosIdCurso",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_CursosIdCurso",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "CursosIdCurso",
                table: "Matricula");

            migrationBuilder.AlterColumn<int>(
                name: "IdCurso",
                table: "Matricula",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IdCurso",
                table: "Matricula",
                column: "IdCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Cursos_IdCurso",
                table: "Matricula",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Cursos_IdCurso",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_IdCurso",
                table: "Matricula");

            migrationBuilder.AddColumn<int>(
                name: "CursosIdCurso",
                table: "Matricula",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdCurso",
                table: "Matricula",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_CursosIdCurso",
                table: "Matricula",
                column: "CursosIdCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Cursos_CursosIdCurso",
                table: "Matricula",
                column: "CursosIdCurso",
                principalTable: "Cursos",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
