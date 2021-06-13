using Microsoft.EntityFrameworkCore.Migrations;

namespace Suls.Migrations
{
    public partial class FixNameAchievedResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArchievedResult",
                table: "Submissions",
                newName: "AchievedResult");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AchievedResult",
                table: "Submissions",
                newName: "ArchievedResult");
        }
    }
}
