using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementApp.Migrations
{
    public partial class addclassforuserv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "users",
                newName: "ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_users_ClassId",
                table: "users",
                newName: "IX_users_ClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_users_classes_ClassID",
                table: "users",
                column: "ClassID",
                principalTable: "classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_classes_ClassID",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "users",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_users_ClassID",
                table: "users",
                newName: "IX_users_ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users",
                column: "ClassId",
                principalTable: "classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
