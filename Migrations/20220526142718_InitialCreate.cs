using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyTrip.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autobus",
                columns: table => new
                {
                    idAutobus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matricule = table.Column<int>(type: "int", nullable: false),
                    capacite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autobus", x => x.idAutobus);
                });

            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    idChauffeur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cinChauffeur = table.Column<int>(type: "int", nullable: false),
                    nomChauffeur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typePermis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.idChauffeur);
                });

            migrationBuilder.CreateTable(
                name: "Excursions",
                columns: table => new
                {
                    idExcur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageExcur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lieuExcur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prixExcur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excursions", x => x.idExcur);
                });

            migrationBuilder.CreateTable(
                name: "Voyages",
                columns: table => new
                {
                    idVoyage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDep = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRetour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idAutobus = table.Column<int>(type: "int", nullable: false),
                    AutobusidAutobus = table.Column<int>(type: "int", nullable: true),
                    idChauffeur = table.Column<int>(type: "int", nullable: false),
                    ChauffeuridChauffeur = table.Column<int>(type: "int", nullable: true),
                    idExcur = table.Column<int>(type: "int", nullable: false),
                    ExcursionidExcur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyages", x => x.idVoyage);
                    table.ForeignKey(
                        name: "FK_Voyages_Autobus_AutobusidAutobus",
                        column: x => x.AutobusidAutobus,
                        principalTable: "Autobus",
                        principalColumn: "idAutobus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voyages_Chauffeurs_ChauffeuridChauffeur",
                        column: x => x.ChauffeuridChauffeur,
                        principalTable: "Chauffeurs",
                        principalColumn: "idChauffeur",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voyages_Excursions_ExcursionidExcur",
                        column: x => x.ExcursionidExcur,
                        principalTable: "Excursions",
                        principalColumn: "idExcur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_AutobusidAutobus",
                table: "Voyages",
                column: "AutobusidAutobus");

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_ChauffeuridChauffeur",
                table: "Voyages",
                column: "ChauffeuridChauffeur");

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_ExcursionidExcur",
                table: "Voyages",
                column: "ExcursionidExcur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voyages");

            migrationBuilder.DropTable(
                name: "Autobus");

            migrationBuilder.DropTable(
                name: "Chauffeurs");

            migrationBuilder.DropTable(
                name: "Excursions");
        }
    }
}
