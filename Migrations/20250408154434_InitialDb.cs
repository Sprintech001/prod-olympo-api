using System;
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
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    VideoPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Website = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "GymUsers",
                columns: table => new
                {
                    GymId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymUsers", x => new { x.UserId, x.GymId });
                    table.ForeignKey(
                        name: "FK_GymUsers_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExercises",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercises", x => new { x.UserId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_UserExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercises_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImagePath", "Name", "VideoPath" },
                values: new object[,]
                {
                    { 1, "Descrição do exercício", "images/exe2.png", "Agachamento Terra", "videos/execucao.mp4" },
                    { 2, "Descrição do exercício", "images/exe.png", "Rosca Concentrada", "videos/execucao.mp4" },
                    { 3, "Descrição do exercício", "images/exe3.png", "Supino Reto", "videos/execucao.mp4" },
                    { 4, "Descrição do exercício", "images/exe4.png", "Puxada Aberta", "videos/execucao.mp4" },
                    { 5, "Descrição do exercício", "images/exe5.png", "Levantamento Terra", "videos/execucao.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CPF", "Email", "ImagePath", "Name", "Password", "Phone", "Type" },
                values: new object[,]
                {
                    { 1, null, "123.456.789-01", "adm@gmail.com", "defaultphoto.jpg", "Admin", "AQAAAAIAAYagAAAAECjeUOGjbRZ/miOwd6biQsmAX8X1vhyE55an6zk7cRm3iiF95n9PeXDmm2Z9oqTvuQ==", null, "Administrador" },
                    { 2, null, "987.654.321-09", "jose@gmail.com", "defaultphoto.jpg", "José", "AQAAAAIAAYagAAAAENfC89Rrz1qhrvw84Qi+mV9IfT+mV+w+1iGST6jnAaSuCa1+2htSTdZN5A8shMO/7g==", null, "Professor" },
                    { 3, null, "111.222.333-44", "maria@gmail.com", "defaultphoto.jpg", "Maria", "AQAAAAIAAYagAAAAEAIF83H6XL6/hVjUwy5CjxpzVcP0GuCdSBm4hY7K9YpMZ2TYs8oRLkbsdzCKQ87eBg==", null, "Aluno" },
                    { 4, null, "555.666.777-88", "joao@gmail.com", "defaultphoto.jpg", "João", "AQAAAAIAAYagAAAAEMiAkOnC39G+3lPDkV09defFRelzO+LarWsalDdVGYpm3pUrD+661R0lT5wQo7gipQ==", null, "Aluno" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymUsers_GymId",
                table: "GymUsers",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ExerciseId",
                table: "Sessions",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercises_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymUsers");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "UserExercises");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
