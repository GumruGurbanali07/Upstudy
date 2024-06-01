using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApp.Migrations
{
    /// <inheritdoc />
    public partial class SocialAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSocial_Teachers_TeacherId",
                table: "TeacherSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSocial",
                table: "TeacherSocial");

            migrationBuilder.RenameTable(
                name: "TeacherSocial",
                newName: "TeacherSocials");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSocial_TeacherId",
                table: "TeacherSocials",
                newName: "IX_TeacherSocials_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSocials",
                table: "TeacherSocials",
                column: "TeacherSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSocials_Teachers_TeacherId",
                table: "TeacherSocials",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSocials_Teachers_TeacherId",
                table: "TeacherSocials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSocials",
                table: "TeacherSocials");

            migrationBuilder.RenameTable(
                name: "TeacherSocials",
                newName: "TeacherSocial");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSocials_TeacherId",
                table: "TeacherSocial",
                newName: "IX_TeacherSocial_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSocial",
                table: "TeacherSocial",
                column: "TeacherSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSocial_Teachers_TeacherId",
                table: "TeacherSocial",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
