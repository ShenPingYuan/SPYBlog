using Microsoft.EntityFrameworkCore.Migrations;

namespace SPY.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommentReply",
                newName: "CommentReplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentReplyId",
                table: "CommentReply",
                newName: "Id");
        }
    }
}
