﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsManager.Infrastructure.DatabaseContext.Migrations
{
    public partial class DeleteSSAColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SSA",
                table: "Persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SSA",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
