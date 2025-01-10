using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 

namespace olympo_webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    VideoPath = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Repetitions = table.Column<int>(type: "integer", nullable: false),
                    Series = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<double>(type: "double precision", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Day", "Description", "ImagePath", "Name", "UserId", "VideoPath" },
                values: new object[,]
                {
                    { 1, 5, "Use uma pegada pronada, com as palmas das mãos voltadas para o corpo, para segurar a barra. Mantenha os joelhos flexionados na posição de agachamento, a coluna ereta e alinhada, e as pernas abertas com os pés apontados para fora.", "images/exe2.png", "Agachamento Terra", null, "videos/execucao.mp4" },
                    { 2, 5, "Sente-se em um banco e incline-se levemente, mantendo o peito erguido. Flexione o braço para levantar o halter até o ombro, pause por um segundo no topo e estenda lentamente o braço para retornar à posição inicial.", "images/exe.png", "Rosca Concentrada", null, "videos/execucao.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "Email", "ImagePath", "Name", "Password", "Type" },
                values: new object[,]
                {
                    { 1, "123.456.789-01", "adm@gmail.com", "defaultphoto.jpg", "Admin", "AQAAAAIAAYagAAAAEJpghEzvpdcluIQ6jDytohG4FJ40VQWRE3yDLjQ4GO2GpOEEDj9qT3BftXo43/CbzQ==", "Administrador" },
                    { 2, "987.654.321-09", "jose@gmail.com", "defaultphoto.jpg", "José", "AQAAAAIAAYagAAAAEGjtyVGHEVMEtnLxWZjAY+Sq2tY3pr1pQG5NZ7tNP/FirNZVTYcfARnCwd1q5fNBeg==", "Professor" },
                    { 3, "123.456.789-01", "maria@gmail.com", "defaultphoto.jpg", "Maria", "AQAAAAIAAYagAAAAEF8BqvVR+uofHdCHqJP5ltGTU/TwUlsHW06hfBbt7wRaurXPrjn63YcH5VW4yxo5Qw==", "Aluno" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ExerciseId",
                table: "Sessions",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
