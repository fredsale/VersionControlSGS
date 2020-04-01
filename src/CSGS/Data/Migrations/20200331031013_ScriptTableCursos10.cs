using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableCursos10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AudienciaCurso",
                table: "CursoExt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DuracionCurso",
                table: "CursoExt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinMat",
                table: "CursoExt",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicioClases",
                table: "CursoExt",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicioMat",
                table: "CursoExt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NivelCurso",
                table: "CursoExt",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivosCurso",
                table: "CursoExt",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReqCurso",
                table: "CursoExt",
                maxLength: 254,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemarioCurso",
                table: "CursoExt",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudienciaCurso",
                table: "CursoExt");

            migrationBuilder.DropColumn(
                name: "DuracionCurso",
                table: "CursoExt");

            migrationBuilder.DropColumn(
                name: "FechaFinMat",
                table: "CursoExt");

            migrationBuilder.DropColumn(
                name: "FechaInicioClases",
                table: "CursoExt");

            migrationBuilder.DropColumn(
                name: "FechaInicioMat",
                table: "CursoExt");

            migrationBuilder.DropColumn(
                name: "NivelCurso",
                table: "CursoExt");

            migrationBuilder.DropColumn(
                name: "ObjetivosCurso",
                table: "CursoExt");

            migrationBuilder.DropColumn(
                name: "ReqCurso",
                table: "CursoExt");

            migrationBuilder.DropColumn(
                name: "TemarioCurso",
                table: "CursoExt");
        }
    }
}
