using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ListBookDemo.DB.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Experience = table.Column<double>(type: "REAL", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "JobBases",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Salary = table.Column<double>(type: "REAL", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBases", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "StatusUsers",
                columns: table => new
                {
                    StatusUserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinExperience = table.Column<double>(type: "REAL", nullable: false),
                    SalaryCoefficient = table.Column<double>(type: "REAL", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusUsers", x => x.StatusUserId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Experience = table.Column<double>(type: "REAL", nullable: false),
                    Wallet = table.Column<double>(type: "REAL", nullable: false),
                    StatusUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    JobId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_JobBases_JobId",
                        column: x => x.JobId,
                        principalTable: "JobBases",
                        principalColumn: "JobId");
                    table.ForeignKey(
                        name: "FK_Users_StatusUsers_StatusUserId",
                        column: x => x.StatusUserId,
                        principalTable: "StatusUsers",
                        principalColumn: "StatusUserId");
                });

            migrationBuilder.CreateTable(
                name: "BookHistories",
                columns: table => new
                {
                    BookHistoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookHistories", x => x.BookHistoryId);
                    table.ForeignKey(
                        name: "FK_BookHistories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Experience", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 100.0, "/Image\\NoImage.png", "C# Для  чайников", 50.0 },
                    { 2, 1000.0, "/Image\\NoImage.png", "Чистый код”, Роберт Мартин", 500.0 },
                    { 3, 1000.0, "/Image\\NoImage.png", "Программист-прагматик. Путь от подмастерья к мастеру”, Эндрю Хант и Дэвид Томас", 5000.0 },
                    { 4, 1000.0, "/Image\\NoImage.png", "Рефакторинг. Улучшение существующего кода”, Мартин Фаулер", 5000.0 },
                    { 5, 1000.0, "/Image\\NoImage.png", "Искусство программирования”, Дональд Кнут", 5000.0 },
                    { 6, 1000.0, "/Image\\NoImage.png", "“Шаблоны корпоративных приложений”, Мартин Фаулер", 5000.0 },
                    { 7, 1000.0, "/Image\\NoImage.png", "Алгоритмы. Построение и анализ”, Томас Х. Кормен, Чарльз И. Лейзерсон, Рональд Л. Ривест, Клиффорд Штайн", 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Experience", "ImagePath", "JobId", "Name", "StatusUserId", "Wallet" },
                values: new object[] { 1, 0.0, "/Image\\NoImage.png", null, "TestUser", null, 100000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_BookHistories_BookId",
                table: "BookHistories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookHistories_UserId",
                table: "BookHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_JobId",
                table: "Users",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusUserId",
                table: "Users",
                column: "StatusUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookHistories");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "JobBases");

            migrationBuilder.DropTable(
                name: "StatusUsers");
        }
    }
}
