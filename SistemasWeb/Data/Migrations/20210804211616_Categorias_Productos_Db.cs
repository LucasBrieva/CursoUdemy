using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemasWeb.Data.Migrations
{
    public partial class Categorias_Productos_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TProducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    CostPrice = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<bool>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProducto_TCategoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProducto_CategoriaId",
                table: "TProducto",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TProducto");

            migrationBuilder.DropTable(
                name: "TCategoria");
        }
    }
}
