using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zuri_Portfolio_Explore.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SkillsDetails_user_id",
                table: "SkillsDetails",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsDetails_Users_user_id",
                table: "SkillsDetails",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillsDetails_Users_user_id",
                table: "SkillsDetails");

            migrationBuilder.DropIndex(
                name: "IX_SkillsDetails_user_id",
                table: "SkillsDetails");
        }
    }
}
