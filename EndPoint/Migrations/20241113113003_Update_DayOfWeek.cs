using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EndPoint.Migrations
{
    /// <inheritdoc />
    public partial class Update_DayOfWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Plan",
                newName: "DayOfWeek");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "Plan",
                newName: "Day");
        }
    }
}
