using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityModels.Migrations
{
    public partial class MtThird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleComments_Articles_ArticleId",
                table: "ArticleComments");

            migrationBuilder.DropIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "ArticleComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "ArticleComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
