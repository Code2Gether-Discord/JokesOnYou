using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesOnYou.Web.Api.Migrations
{
    public partial class ChangedModelIntoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jokes_AspNetUsers_AuthorId",
                table: "Jokes");

            migrationBuilder.DropIndex(
                name: "IX_Jokes_AuthorId",
                table: "Jokes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Jokes_AuthorId",
                table: "Jokes",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jokes_AspNetUsers_AuthorId",
                table: "Jokes",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
