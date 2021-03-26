using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityModels.Migrations
{
    public partial class Fouth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleComments_Articles_ArticleId",
                table: "ArticleComments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleComments_Articles_ArticleId",
                table: "ArticleComments");

            migrationBuilder.DropIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments");
        }
    }
}
