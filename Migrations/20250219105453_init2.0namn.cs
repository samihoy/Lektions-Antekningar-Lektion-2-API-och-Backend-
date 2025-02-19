using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lektion_2__API_Backend___Code_First_Database.Migrations
{
    /// <inheritdoc />
    public partial class init20namn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassCourses_Classes_ClassID",
                table: "ClassCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_ClassCourses_ClassID",
                table: "ClassCourses");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "ClassCourses");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassID_FK",
                table: "Students",
                column: "ClassID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ClassCourses_CLassID_FK",
                table: "ClassCourses",
                column: "CLassID_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassCourses_Classes_CLassID_FK",
                table: "ClassCourses",
                column: "CLassID_FK",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassID_FK",
                table: "Students",
                column: "ClassID_FK",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassCourses_Classes_CLassID_FK",
                table: "ClassCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassID_FK",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassID_FK",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_ClassCourses_CLassID_FK",
                table: "ClassCourses");

            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                table: "ClassCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassID",
                table: "Students",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassCourses_ClassID",
                table: "ClassCourses",
                column: "ClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassCourses_Classes_ClassID",
                table: "ClassCourses",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassID",
                table: "Students",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
