using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace olympo_webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "Email", "Name", "Password", "Photo" },
                values: new object[] { 1, "123.456.789-01", "adm@gmail.com", "Admin", "password", "defaultphoto.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
