using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlServer.Data.Migrations.Contacts
{
    public partial class ContactTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Contacts",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Contacts");
        }
    }
}
