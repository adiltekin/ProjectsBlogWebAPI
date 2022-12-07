using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectsBlogWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class datetimeprojectmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "startDate",
                table: "Projects",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "Projects");
        }
    }
}
