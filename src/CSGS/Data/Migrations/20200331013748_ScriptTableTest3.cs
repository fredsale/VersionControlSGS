using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableTest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AudienciaCurso = table.Column<int>(nullable: false),
                    DescripcionCurso = table.Column<string>(maxLength: 255, nullable: true),
                    DuracionCurso = table.Column<int>(nullable: false),
                    FechaFinMat = table.Column<DateTime>(nullable: true),
                    FechaInicioClases = table.Column<DateTime>(nullable: true),
                    FechaInicioMat = table.Column<DateTime>(nullable: true),
                    IdAdmin = table.Column<string>(nullable: true),
                    IdCategoria = table.Column<int>(nullable: false),
                    NivelCurso = table.Column<string>(maxLength: 100, nullable: true),
                    ObjetivosCurso = table.Column<string>(maxLength: 255, nullable: true),
                    ReqCurso = table.Column<string>(maxLength: 254, nullable: true),
                    TemarioCurso = table.Column<string>(maxLength: 450, nullable: true),
                    TituloCurso = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fechamatricula = table.Column<DateTime>(nullable: true),
                    IdCurso = table.Column<int>(nullable: false),
                    IdEstudiante = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.IdMatricula);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Matricula");
        }
    }
}
