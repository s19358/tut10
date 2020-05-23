using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial10.Migrations
{
    public partial class Deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDoctorNavigationIdDoctor",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPatientNavigationIdPatient",
                table: "Prescription",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctorNavigationIdDoctor",
                table: "Prescription",
                column: "IdDoctorNavigationIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatientNavigationIdPatient",
                table: "Prescription",
                column: "IdPatientNavigationIdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctor_IdDoctorNavigationIdDoctor",
                table: "Prescription",
                column: "IdDoctorNavigationIdDoctor",
                principalTable: "Doctor",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patient_IdPatientNavigationIdPatient",
                table: "Prescription",
                column: "IdPatientNavigationIdPatient",
                principalTable: "Patient",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doctor_IdDoctorNavigationIdDoctor",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patient_IdPatientNavigationIdPatient",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_IdDoctorNavigationIdDoctor",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_IdPatientNavigationIdPatient",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "IdDoctorNavigationIdDoctor",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "IdPatientNavigationIdPatient",
                table: "Prescription");
        }
    }
}
