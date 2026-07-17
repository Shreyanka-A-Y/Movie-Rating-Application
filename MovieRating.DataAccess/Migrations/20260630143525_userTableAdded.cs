using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRating.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class userTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Movies_MovieId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "MovieId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "MovieId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "MovieId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieId",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Movies_MovieId",
                table: "Movies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
