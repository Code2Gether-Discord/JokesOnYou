using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesOnYou.Web.Api.Migrations
{
    public partial class ChangedModelIntoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Jokes_AspNetUsers_AuthorId",
                table: "Jokes",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jokes_AspNetUsers_AuthorId",
                table: "Jokes");

            migrationBuilder.DropIndex(
                name: "IX_Jokes_AuthorId",
                table: "Jokes");
        }
    }
}
