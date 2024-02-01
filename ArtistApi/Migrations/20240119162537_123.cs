using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistApi.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FK_ArtistId = table.Column<int>(type: "int", nullable: false),
                    FK_GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_FK_ArtistId",
                        column: x => x.FK_ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_FK_GenreId",
                        column: x => x.FK_GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ArtistName" },
                values: new object[,]
                {
                    { 1, "Beatles" },
                    { 2, "Creedense" },
                    { 3, "The Script" },
                    { 4, "McFly" },
                    { 5, "Frank Sinatra" },
                    { 6, "Steve Lacy" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "Rock" },
                    { 3, "Jazz" },
                    { 4, "Funck" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "DisplayName" },
                values: new object[,]
                {
                    { "Admin", "Administrator" },
                    { "Guest", "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "FK_ArtistId", "FK_GenreId", "Title" },
                values: new object[,]
                {
                    { 1, 2, 1, "Fortunate song" },
                    { 2, 1, 2, "Let it be" },
                    { 3, 4, 1, "All About You" },
                    { 4, 4, 1, "Five Colours in Her Hair" },
                    { 5, 3, 2, "Breakeven" },
                    { 6, 3, 1, "Superheroes" },
                    { 7, 5, 1, "My Way" },
                    { 8, 6, 3, "Dark Red" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_FK_ArtistId",
                table: "Songs",
                column: "FK_ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_FK_GenreId",
                table: "Songs",
                column: "FK_GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
