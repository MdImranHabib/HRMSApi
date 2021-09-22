using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSApi.Migrations
{
    public partial class createdResidentFlatclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResidentFlats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentId = table.Column<int>(nullable: false),
                    FlatId = table.Column<int>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentFlats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentFlats_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentFlats_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentFlats_FlatId",
                table: "ResidentFlats",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentFlats_ResidentId",
                table: "ResidentFlats",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentFlats");
        }
    }
}
