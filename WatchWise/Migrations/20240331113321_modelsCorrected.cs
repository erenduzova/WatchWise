using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchWise.Migrations
{
    /// <inheritdoc />
    public partial class modelsCorrected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Episodes_MediaId",
                table: "Episodes");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_MediaId_SeasonNum_EpisodeNum",
                table: "Episodes",
                columns: new[] { "MediaId", "SeasonNum", "EpisodeNum" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Episodes_MediaId_SeasonNum_EpisodeNum",
                table: "Episodes");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_MediaId",
                table: "Episodes",
                column: "MediaId");
        }
    }
}
