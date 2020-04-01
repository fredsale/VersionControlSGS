using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableCursos6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.CreateTable(
                name: "Prueba2",
                columns: table => new
                {
                    IdPrueba2 = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombrePrueba2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prueba2", x => x.IdPrueba2);
                });

            migrationBuilder.CreateTable(
                name: "Prueba1",
                columns: table => new
                {
                    IdPrueba1 = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionViaje = table.Column<string>(nullable: true),
                    DuracionViaje = table.Column<int>(nullable: false),
                    FechaViaje = table.Column<DateTime>(nullable: true),
                    GastosHotel = table.Column<decimal>(nullable: false),
                    GastosMovilidad = table.Column<decimal>(nullable: false),
                    IdPrueba2 = table.Column<int>(nullable: false),
                    IdSolicitante = table.Column<string>(maxLength: 450, nullable: true),
                    IdSupervisor = table.Column<string>(nullable: true),
                    MontoGastar = table.Column<decimal>(nullable: false),
                    SustentoSupervisor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prueba1", x => x.IdPrueba1);
                    table.ForeignKey(
                        name: "FK_Prueba1_Prueba2_IdPrueba2",
                        column: x => x.IdPrueba2,
                        principalTable: "Prueba2",
                        principalColumn: "IdPrueba2",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prueba1_IdPrueba2",
                table: "Prueba1",
                column: "IdPrueba2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prueba1");

            migrationBuilder.DropTable(
                name: "Prueba2");

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
                    table.ForeignKey(
                        name: "FK_Matricula_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IdCurso",
                table: "Matricula",
                column: "IdCurso");
        }
    }
}
