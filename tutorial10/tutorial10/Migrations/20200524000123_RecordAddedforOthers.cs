using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial10.Migrations
{
    public partial class RecordAddedforOthers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1,
                column: "Description",
                value: "for pain");

            migrationBuilder.UpdateData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 2,
                column: "Description",
                value: "for pain");

            migrationBuilder.UpdateData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 3,
                column: "Description",
                value: "for cold");

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 1, 1, "once a week", 1 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 2, 2, "twice a day", 2 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 3, 3, "once a day", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1,
                column: "Description",
                value: "for pain");

            migrationBuilder.UpdateData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 2,
                column: "Description",
                value: "for pain");

            migrationBuilder.UpdateData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 3,
                column: "Description",
                value: "for cold");
        }
    }
}
