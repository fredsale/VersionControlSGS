using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSGS.Data.Migrations
{
    public partial class ScriptTableTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Categoria_CategoriaIdCategoria",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_CategoriaIdCategoria",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "IdMotivo",
                table: "Cursos");

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Cursos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdCategoria",
                table: "Cursos",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Categoria_IdCategoria",
                table: "Cursos",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Categoria_IdCategoria",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_IdCategoria",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Cursos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Cursos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMotivo",
                table: "Cursos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CategoriaIdCategoria",
                table: "Cursos",
                column: "CategoriaIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Categoria_CategoriaIdCategoria",
                table: "Cursos",
                column: "CategoriaIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
