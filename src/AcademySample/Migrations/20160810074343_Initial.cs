using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademySample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerDetails",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    Memory = table.Column<int>(nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerDetails", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "UsageData",
                columns: table => new
                {
                    UsageDataId = table.Column<Guid>(nullable: false),
                    AvailableDiskSpace = table.Column<int>(nullable: false),
                    ComputerName = table.Column<string>(nullable: true),
                    CpuUsage = table.Column<int>(nullable: false),
                    MemoryUsage = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageData", x => x.UsageDataId);
                    table.ForeignKey(
                        name: "FK_UsageData_ComputerDetails_ComputerName",
                        column: x => x.ComputerName,
                        principalTable: "ComputerDetails",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsageData_ComputerName",
                table: "UsageData",
                column: "ComputerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsageData");

            migrationBuilder.DropTable(
                name: "ComputerDetails");
        }
    }
}
