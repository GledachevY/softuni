using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballArenas.Data.Migrations
{
    public partial class deleteIdOgImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
