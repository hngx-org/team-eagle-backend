using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Zuri_Portfolio_Explore.Migrations
{
    public partial class UserUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    meta = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialUsers_social_media_id",
                table: "SocialUsers",
                column: "social_media_id");

            migrationBuilder.CreateIndex(
                name: "IX_SocialUsers_user_id",
                table: "SocialUsers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsDetails_section_id",
                table: "SkillsDetails",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsDetails_user_id",
                table: "SkillsDetails",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsDetails_Sections_section_id",
                table: "SkillsDetails",
                column: "section_id",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsDetails_Users_user_id",
                table: "SkillsDetails",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialUsers_SocialMedias_social_media_id",
                table: "SocialUsers",
                column: "social_media_id",
                principalTable: "SocialMedias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialUsers_Users_user_id",
                table: "SocialUsers",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillsDetails_Sections_section_id",
                table: "SkillsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsDetails_Users_user_id",
                table: "SkillsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialUsers_SocialMedias_social_media_id",
                table: "SocialUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialUsers_Users_user_id",
                table: "SocialUsers");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_SocialUsers_social_media_id",
                table: "SocialUsers");

            migrationBuilder.DropIndex(
                name: "IX_SocialUsers_user_id",
                table: "SocialUsers");

            migrationBuilder.DropIndex(
                name: "IX_SkillsDetails_section_id",
                table: "SkillsDetails");

            migrationBuilder.DropIndex(
                name: "IX_SkillsDetails_user_id",
                table: "SkillsDetails");
        }
    }
}
