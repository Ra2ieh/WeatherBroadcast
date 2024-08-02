using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherBroadcast.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    GenerationtimeMs = table.Column<double>(type: "float", nullable: false),
                    UtcOffsetSeconds = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimezoneAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elevation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hourly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature2m = table.Column<double>(type: "float", nullable: false),
                    WeatherDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hourly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hourly_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HourlyUnits",
                columns: table => new
                {
                    WeatherDataId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature2m = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyUnits", x => x.WeatherDataId);
                    table.ForeignKey(
                        name: "FK_HourlyUnits_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hourly_WeatherDataId",
                table: "Hourly",
                column: "WeatherDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hourly");

            migrationBuilder.DropTable(
                name: "HourlyUnits");

            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}
