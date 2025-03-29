using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    UserId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Exercises_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    DayOfWeek = table.Column<string>(type: "text", nullable: false),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseDays_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Repetitions = table.Column<int>(type: "integer", nullable: false),
                    Series = table.Column<int>(type: "integer", nullable: false),
                    Breaks = table.Column<double>(type: "double precision", nullable: false),
                    Time = table.Column<double>(type: "double precision", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "Email", "ImagePath", "Name", "Password", "Type" },
                values: new object[,]
                {
                    { 1, "123.456.789-01", "adm@gmail.com", "defaultphoto.jpg", "Admin", "AQAAAAIAAYagAAAAEMlYThVyOa5W1NWU3FdZAMXdSQycEU5cpvd3j0sQwZzawuv0C8dDj5jRG+7IrH/mWQ==", "Administrador" },
                    { 2, "987.654.321-09", "jose@gmail.com", "defaultphoto.jpg", "José", "AQAAAAIAAYagAAAAECxGMqRRRInmQyfEgq6wB1xaosd+kB6qLnClfZevHFi6QEXTgl79i+1pdwaVu/Yxvw==", "Professor" },
                    { 3, "111.222.333-44", "maria@gmail.com", "defaultphoto.jpg", "Maria", "AQAAAAIAAYagAAAAEIlCw2pIoqVlhW2QXFijk2jmOEdVy4ZI3oQjjfeXIksqcVBGkC5nFET71sy+4sWZtA==", "Aluno" },
                    { 4, "555.666.777-88", "joao@gmail.com", "defaultphoto.jpg", "João", "AQAAAAIAAYagAAAAEOiiFlwg+6y/M6fWsYs4FtAasDgmveVNkyRdrsKwWVhGPb2dwsI2gNyqsh6jS/9ZPQ==", "Aluno" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImagePath", "Name", "UserId", "UserId1", "VideoPath" },
                values: new object[,]
                {
                    { 1, "Descrição do exercício", "images/exe2.png", "Agachamento Terra", 3, null, "videos/execucao.mp4" },
                    { 2, "Descrição do exercício", "images/exe.png", "Rosca Concentrada", 4, null, "videos/execucao.mp4" },
                    { 3, "Descrição do exercício", "images/exe3.png", "Supino Reto", 3, null, "videos/execucao.mp4" },
                    { 4, "Descrição do exercício", "images/exe4.png", "Puxada Aberta", 3, null, "videos/execucao.mp4" },
                    { 5, "Descrição do exercício", "images/exe5.png", "Levantamento Terra", 4, null, "videos/execucao.mp4" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseDays",
                columns: new[] { "Id", "DayOfWeek", "ExerciseId", "SessionId", "UserId" },
                values: new object[,]
                {
                    { 1, "Segunda", 1, 1, 3 },
                    { 2, "Terça", 2, 2, 4 },
                    { 3, "Quarta", 3, 3, 3 },
                    { 4, "Domingo", 4, 4, 3 },
                    { 5, "Segunda", 5, 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Breaks", "ExerciseId", "Repetitions", "Series", "Time" },
                values: new object[,]
                {
                    { 1, 60.0, 1, 10, 3, 5.0 },
                    { 2, 45.0, 2, 12, 4, 6.0 },
                    { 3, 90.0, 3, 8, 5, 7.5 },
                    { 4, 30.0, 4, 15, 3, 4.5 },
                    { 5, 120.0, 5, 6, 6, 10.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDays_ExerciseId",
                table: "ExerciseDays",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserId1",
                table: "Exercises",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ExerciseId",
                table: "Sessions",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseDays");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
