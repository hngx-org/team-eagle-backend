using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Zuri_Portfolio_Explore.Migrations
{
    public partial class updatesmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_role_id",
                table: "UserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_user_id",
                table: "Projects",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_user_id",
                table: "Projects",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Role_role_id",
                table: "UserRoles",
                column: "role_id",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_user_id",
                table: "UserRoles",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_user_id",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Role_role_id",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_user_id",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_role_id",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Projects_user_id",
                table: "Projects");
        }
    }
}
