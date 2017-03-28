using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSqlite.Migrations
{
    public partial class RenameContactStateToSubregion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"PRAGMA foreign_keys = 0;

                  CREATE TABLE Contacts_temp AS SELECT *
                                                FROM Contacts;
                  
                  DROP TABLE Contacts;
                  
                  CREATE TABLE Contacts (
                      Id         INTEGER NOT NULL
                                         CONSTRAINT PK_Contacts PRIMARY KEY AUTOINCREMENT,
                      Address    TEXT,
                      City       TEXT,
                      Email      TEXT,
                      Name       TEXT,
                      Phone      TEXT,
                      PostalCode TEXT,
                      Subregion  TEXT
                  );
                  
                  INSERT INTO Contacts 
                  (
                      Id,
                      Address,
                      City,
                      Email,
                      Name,
                      Phone,
                      PostalCode,
                      Subregion
                  )
                  SELECT Id,
                         Address,
                         City,
                         Email,
                         Name,
                         Phone,
                         PostalCode,
                         State
                  FROM Contacts_temp;
                  
                  DROP TABLE Contacts_temp;
                  
                  PRAGMA foreign_keys = 1;");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
