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
                    Elevation = table.Column<double>(type: "float", nullable: false),
                    HourlyUnits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hourly = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}
