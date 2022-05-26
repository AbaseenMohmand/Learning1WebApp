using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning1.DataAccess.Migrations
{
    public partial class emptblupdt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "employyes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_employyes_DesignationId",
                table: "employyes",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_employyes_designations_DesignationId",
                table: "employyes",
                column: "DesignationId",
                principalTable: "designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employyes_designations_DesignationId",
                table: "employyes");

            migrationBuilder.DropIndex(
                name: "IX_employyes_DesignationId",
                table: "employyes");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "employyes");
        }
    }
}
