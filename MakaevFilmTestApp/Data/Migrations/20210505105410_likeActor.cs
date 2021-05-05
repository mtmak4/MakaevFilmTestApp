using Microsoft.EntityFrameworkCore.Migrations;

namespace MakaevFilmTestApp.Data.Migrations
{
    public partial class likeActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ActorLike_ActorIdId",
                table: "ActorLike");

            migrationBuilder.DropColumn(
                name: "ActorIdId",
                table: "ActorLike");

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "ActorLike",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "ActorLike");

            migrationBuilder.AddColumn<int>(
                name: "ActorIdId",
                table: "ActorLike",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorLike_ActorIdId",
                table: "ActorLike",
                column: "ActorIdId");
        }
    }
}
