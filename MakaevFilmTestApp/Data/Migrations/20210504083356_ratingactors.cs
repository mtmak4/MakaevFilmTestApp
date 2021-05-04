using Microsoft.EntityFrameworkCore.Migrations;

namespace MakaevFilmTestApp.Data.Migrations
{
    public partial class ratingactors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_ActorLike_Actors_ActorIdId",
                table: "ActorLike",
                column: "ActorIdId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorLike_Actors_ActorIdId",
                table: "ActorLike");

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
    }
}
