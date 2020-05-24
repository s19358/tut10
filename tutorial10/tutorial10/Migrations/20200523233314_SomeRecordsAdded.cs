using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial10.Migrations
{
    public partial class SomeRecordsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "bilal@gmail.com", "Bilal", "Ozgur" },
                    { 2, "reyhan@gmail.com", "Reyhan", "Ozgur" },
                    { 3, "ali@gmail.com", "Ali", "Yilmaz" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1997, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Busra", "Yildiz" },
                    { 2, new DateTime(1995, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berkay", "Koyuncu" },
                    { 3, new DateTime(1997, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Merve", "Unal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3);
        }
    }
}
