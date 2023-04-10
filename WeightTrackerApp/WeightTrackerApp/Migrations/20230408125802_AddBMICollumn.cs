using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeightTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddBMICollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BIMValue",
                table: "Weights",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BIMValue",
                table: "Weights");
        }
    }
}
