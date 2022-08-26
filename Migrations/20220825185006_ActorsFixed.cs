using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPI.Migrations
{
    public partial class ActorsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actros_ActorsActorId",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actros",
                table: "Actros");

            migrationBuilder.RenameTable(
                name: "Actros",
                newName: "Actors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie",
                column: "ActorsActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Actros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actros",
                table: "Actros",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actros_ActorsActorId",
                table: "ActorMovie",
                column: "ActorsActorId",
                principalTable: "Actros",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
