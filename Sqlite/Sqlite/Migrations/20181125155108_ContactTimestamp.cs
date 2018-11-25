using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSqlite.Migrations
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

            migrationBuilder.Sql(
                @"
                CREATE TRIGGER SetContactTimestampOnUpdate
                AFTER UPDATE ON Contacts
                BEGIN
                    UPDATE Contacts
                    SET Timestamp = randomblob(8)
                    WHERE rowid = NEW.rowid;
                END
            ");

            migrationBuilder.Sql(
                @"
                CREATE TRIGGER SetContactTimestampOnInsert
                AFTER INSERT ON Contacts
                BEGIN
                    UPDATE Contacts
                    SET Timestamp = randomblob(8)
                    WHERE rowid = NEW.rowid;
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Contacts");
        }
    }
}
