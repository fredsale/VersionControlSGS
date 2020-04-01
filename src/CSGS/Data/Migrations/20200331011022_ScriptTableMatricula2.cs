using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableMatricula2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCategoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AudienciaCurso = table.Column<int>(nullable: false),
                    CategoriaIdCategoria = table.Column<int>(nullable: true),
                    DescripcionCurso = table.Column<string>(maxLength: 255, nullable: true),
                    DuracionCurso = table.Column<int>(nullable: false),
                    FechaFinMat = table.Column<DateTime>(nullable: true),
                    FechaInicioClases = table.Column<DateTime>(nullable: true),
                    FechaInicioMat = table.Column<DateTime>(nullable: true),
                    IdAdmin = table.Column<string>(nullable: true),
                    IdMotivo = table.Column<int>(nullable: false),
                    NivelCurso = table.Column<string>(maxLength: 100, nullable: true),
                    ObjetivosCurso = table.Column<string>(maxLength: 255, nullable: true),
                    ReqCurso = table.Column<string>(maxLength: 254, nullable: true),
                    TemarioCurso = table.Column<string>(maxLength: 450, nullable: true),
                    TituloCurso = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK_Cursos_Categoria_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CursosIdCurso = table.Column<int>(nullable: true),
                    Fechamatricula = table.Column<DateTime>(nullable: true),
                    IdCurso = table.Column<string>(nullable: true),
                    IdEstudiante = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.IdMatricula);
                    table.ForeignKey(
                        name: "FK_Matricula_Cursos_CursosIdCurso",
                        column: x => x.CursosIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CategoriaIdCategoria",
                table: "Cursos",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_CursosIdCurso",
                table: "Matricula",
                column: "CursosIdCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
