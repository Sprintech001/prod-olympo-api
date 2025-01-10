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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEJpghEzvpdcluIQ6jDytohG4FJ40VQWRE3yDLjQ4GO2GpOEEDj9qT3BftXo43/CbzQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEGjtyVGHEVMEtnLxWZjAY+Sq2tY3pr1pQG5NZ7tNP/FirNZVTYcfARnCwd1q5fNBeg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEF8BqvVR+uofHdCHqJP5ltGTU/TwUlsHW06hfBbt7wRaurXPrjn63YcH5VW4yxo5Qw==");
        }
    }
}
