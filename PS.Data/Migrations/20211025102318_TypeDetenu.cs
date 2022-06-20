using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class TypeDetenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Chemicals",
                newName: "Address_StreetAddress");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Chemicals",
                newName: "Address_City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_StreetAddress",
                table: "Chemicals",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Chemicals",
                newName: "City");
        }
    }
}
