using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableSolicitud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    IdEstado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreEstado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionViaje = table.Column<string>(nullable: true),
                    DuracionViaje = table.Column<int>(nullable: false),
                    FechaViaje = table.Column<DateTime>(nullable: false),
                    GastosHotel = table.Column<decimal>(nullable: false),
                    GastosMovilidad = table.Column<decimal>(nullable: false),
                    IdEstado = table.Column<int>(nullable: false),
                    IdMotivo = table.Column<int>(nullable: false),
                    IdSolicitante = table.Column<int>(nullable: false),
                    IdSupervisor = table.Column<int>(nullable: false),
                    MontoGastar = table.Column<decimal>(nullable: false),
                    SustentoSupervisor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.IdSolicitud);
                    table.ForeignKey(
                        name: "FK_Solicitud_Estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_IdEstado",
                table: "Solicitud",
                column: "IdEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
