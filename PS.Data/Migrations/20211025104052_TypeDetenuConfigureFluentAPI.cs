using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class TypeDetenuConfigureFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_StreetAddress",
                table: "Chemicals",
                newName: "MyStreet");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Chemicals",
                newName: "MyCity");

            migrationBuilder.AlterColumn<string>(
                name: "MyStreet",
                table: "Chemicals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MyCity",
                table: "Chemicals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyStreet",
                table: "Chemicals",
                newName: "Address_StreetAddress");

            migrationBuilder.RenameColumn(
                name: "MyCity",
                table: "Chemicals",
                newName: "Address_City");

            migrationBuilder.AlterColumn<string>(
                name: "Address_StreetAddress",
                table: "Chemicals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_City",
                table: "Chemicals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
