using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication22.Migrations
{
    public partial class addModelsTodatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GithubUserDetails",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GithubUserDetails", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "GithubRepositories",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HtmlUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchersCount = table.Column<int>(type: "int", nullable: false),
                    GithubUserDetailsUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GithubRepositories", x => x.Name);
                    table.ForeignKey(
                        name: "FK_GithubRepositories_GithubUserDetails_GithubUserDetailsUserId",
                        column: x => x.GithubUserDetailsUserId,
                        principalTable: "GithubUserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GithubRepositories_GithubUserDetailsUserId",
                table: "GithubRepositories",
                column: "GithubUserDetailsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GithubRepositories");

            migrationBuilder.DropTable(
                name: "GithubUserDetails");
        }
    }
}
