using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListBookDemo.DB.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Wallet",
                table: "Users",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Wallet",
                value: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "Users");
        }
    }
}
