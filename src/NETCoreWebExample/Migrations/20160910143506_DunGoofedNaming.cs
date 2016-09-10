using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCoreWebExample.Migrations
{
    public partial class DunGoofedNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Longitutde",
                table: "Stops");

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Stops",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Stops");

            migrationBuilder.AddColumn<double>(
                name: "Longitutde",
                table: "Stops",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
