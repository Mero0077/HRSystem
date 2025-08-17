using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Attendances",
                newName: "EmpId");

            migrationBuilder.RenameColumn(
                name: "ClockOutTime",
                table: "Attendances",
                newName: "CheckOutTime");

            migrationBuilder.RenameColumn(
                name: "ClockInTime",
                table: "Attendances",
                newName: "CheckInTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Attendances",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "CheckOutTime",
                table: "Attendances",
                newName: "ClockOutTime");

            migrationBuilder.RenameColumn(
                name: "CheckInTime",
                table: "Attendances",
                newName: "ClockInTime");
        }
    }
}
