using Microsoft.EntityFrameworkCore.Migrations;

namespace MakaevFilmTestApp.Data.Migrations
{
    public partial class userId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ActorLikeSettings");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ActorLikeSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ActorLikeSettings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ActorLikeSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
