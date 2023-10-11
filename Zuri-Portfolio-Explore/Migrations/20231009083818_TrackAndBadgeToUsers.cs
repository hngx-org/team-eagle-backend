using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zuri_Portfolio_Explore.Migrations
{
    public partial class TrackAndBadgeToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles");

            migrationBuilder.AddColumn<string>(
                name: "Ranking",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Track",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles",
                column: "user_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Track",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles",
                column: "user_id");
        }
    }
}
