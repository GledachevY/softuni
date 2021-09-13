using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballArenas.Data.Migrations
{
    public partial class addIdToAdresstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportComplexes_Addresses_AddressId",
                table: "SportComplexes");

            migrationBuilder.DropIndex(
                name: "IX_SportComplexes_AddressId",
                table: "SportComplexes");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "SportComplexes");

            migrationBuilder.AddColumn<int>(
                name: "SportComplexId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SportComplexId",
                table: "Addresses",
                column: "SportComplexId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_SportComplexes_SportComplexId",
                table: "Addresses",
                column: "SportComplexId",
                principalTable: "SportComplexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_SportComplexes_SportComplexId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_SportComplexId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "SportComplexId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "SportComplexes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SportComplexes_AddressId",
                table: "SportComplexes",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportComplexes_Addresses_AddressId",
                table: "SportComplexes",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
