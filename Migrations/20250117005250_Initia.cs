using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace olympo_webapi.Migrations
{
    /// <inheritdoc />
    public partial class Initia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEC06Xg2znmDDB3+grBDpOpWJtmQD5fQ8v7irnrczfskf8EMtFd6sCUCGdSVC71YG/Q==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEGxHsoYGFMnd/JgUsgOvLU7zg//hFoibcL5QepDdPgGq7YLElBmODh5Fgc2brs25VA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAENecS3o44ESqlgy9rujQf4BEbwIN7qjimFSIgoTdw3eZefh3/b0QkYKFe1USGw1Hkw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEGz1uBiy+TMBGyTsFrKZBsXcSH0aanfT78hRJAO+BkOCIK0LH4lmP4s1BH2ZEaT33A==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAELQiroQuBETEzbi+6watlapd/T/HDs7+tUXMfvVsQ5iJkkqstVyohnQCC1EgZQzYPg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEEWvxgDNSyImvHes32BvugcsZMfM+OmMp/HbVaX7is7cvjJ+xHvpbl+ZK93fOZzuGg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEMxiwgUpT1xx1qQFQ6dzIk4QzB/jneys0wwDwWgFKJtSDB8u0EHMhqQcg00KdToSrQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEEZms7z0OZCi6JI27Z9/3aMYZn5UL9u7VYCFAzAEx63BNjNm+SdzvnSxJegF9e1fBQ==");
        }
    }
}
