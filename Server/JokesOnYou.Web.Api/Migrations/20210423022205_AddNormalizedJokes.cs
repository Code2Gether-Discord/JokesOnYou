using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesOnYou.Web.Api.Migrations
{
    public partial class AddNormalizedJokes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedPremise",
                table: "Jokes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedPunchLine",
                table: "Jokes",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedPremise",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "NormalizedPunchLine",
                table: "Jokes");
        }
    }
}
