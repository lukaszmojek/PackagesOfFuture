using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class IdPropertyRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Posts_AdressId",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Adresses");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Clients");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Adresses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AdressId",
                table: "Clients",
                newName: "IX_Clients_AdressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Adresses_AdressId",
                table: "Clients",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Adresses_AdressId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Blogs");

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "Posts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Blogs",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_AdressId",
                table: "Blogs",
                newName: "IX_Blogs_AdressId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Posts_AdressId",
                table: "Blogs",
                column: "AdressId",
                principalTable: "Posts",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
