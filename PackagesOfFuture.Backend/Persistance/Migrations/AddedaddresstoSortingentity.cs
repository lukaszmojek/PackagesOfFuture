using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddedaddresstoSortingentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Sortings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sortings_AddressId",
                table: "Sortings",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sortings_Addresses_AddressId",
                table: "Sortings",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sortings_Addresses_AddressId",
                table: "Sortings");

            migrationBuilder.DropIndex(
                name: "IX_Sortings_AddressId",
                table: "Sortings");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Sortings");
        }
    }
}
