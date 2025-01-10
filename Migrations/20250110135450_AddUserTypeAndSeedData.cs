using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace olympo_webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTypeAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAELH/xtH5SF1Fjb8zzJZt+cZBlyVM7vIcheMrt3Hi6+YNt3UMHr9cengUeRfy5dltLg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEPTvgVu8hM/4SPVVaaqssIz53ZVinAcMzdAEOgGVF+YCtQae5246kirYxZf7dWtNRg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEOAPV87xi1OZbnG8mUIqHvtXG/Alh3fkHtHn7dLMYsouR/4/Tx0a5KS3wprfqwhKRg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAECTiJGW36W+Xj+hhLui4qI8gmkAPTOvJ9SEpuvqCVTJEtXW9drLPAioAO/xQ+emt4w==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEDe9Pkx0cdjQBVVGBDAQKgekU/WMkkQ5IrSxoxvoJPnrdlhUhX2+Jy0Plki6DZgh3A==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEJq7Er/hlF6Boapu0FqA7bdQ+/VR23d9d89Dz+MSN0vU8L7H7Nb2hMw5IS62fjm6jw==");
        }
    }
}
