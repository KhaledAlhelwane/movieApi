using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_with_dev_creed.Migrations
{
    public partial class editMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Geners_GenerId1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenerId1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenerId1",
                table: "Movies");

            migrationBuilder.AlterColumn<byte>(
                name: "GenerId",
                table: "Movies",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenerId",
                table: "Movies",
                column: "GenerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Geners_GenerId",
                table: "Movies",
                column: "GenerId",
                principalTable: "Geners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Geners_GenerId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenerId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "GenerId",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<byte>(
                name: "GenerId1",
                table: "Movies",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenerId1",
                table: "Movies",
                column: "GenerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Geners_GenerId1",
                table: "Movies",
                column: "GenerId1",
                principalTable: "Geners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
