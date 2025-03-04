using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Lecturer_LecturerId",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_LecturerId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "Class");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "AttendanceLog",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "AttendanceLog");

            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Class_LecturerId",
                table: "Class",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Lecturer_LecturerId",
                table: "Class",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
