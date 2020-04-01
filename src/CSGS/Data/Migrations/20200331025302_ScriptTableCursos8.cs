using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableCursos8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CursoExt",
                columns: table => new
                {
                    IdCursoExt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionCursoExt = table.Column<string>(maxLength: 255, nullable: true),
                    IdAdmin = table.Column<string>(nullable: true),
                    TituloCursoExt = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoExt", x => x.IdCursoExt);
                });

            migrationBuilder.CreateTable(
                name: "MatriculaDoc",
                columns: table => new
                {
                    IdMatriculaDoc = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fechamatricula = table.Column<DateTime>(nullable: true),
                    IdCursoExt = table.Column<int>(nullable: false),
                    IdEstudiante = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatriculaDoc", x => x.IdMatriculaDoc);
                    table.ForeignKey(
                        name: "FK_MatriculaDoc_CursoExt_IdCursoExt",
                        column: x => x.IdCursoExt,
                        principalTable: "CursoExt",
                        principalColumn: "IdCursoExt",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatriculaDoc_IdCursoExt",
                table: "MatriculaDoc",
                column: "IdCursoExt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatriculaDoc");

            migrationBuilder.DropTable(
                name: "CursoExt");
        }
    }
}
