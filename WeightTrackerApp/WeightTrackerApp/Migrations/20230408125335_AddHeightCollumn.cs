﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeightTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddHeightCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HeightValue",
                table: "Weights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeightValue",
                table: "Weights");
        }
    }
}
