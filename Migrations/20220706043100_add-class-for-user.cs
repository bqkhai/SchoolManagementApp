using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementApp.Migrations
{
    public partial class addclassforuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users",
                column: "ClassId",
                principalTable: "classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users",
                column: "ClassId",
                principalTable: "classes",
                principalColumn: "ClassId");
        }
    }
}
