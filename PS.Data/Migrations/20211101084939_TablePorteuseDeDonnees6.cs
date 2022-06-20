using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class TablePorteuseDeDonnees6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Facture",
                table: "Facture");

            migrationBuilder.DropIndex(
                name: "IX_Facture_ClientFk",
                table: "Facture");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facture",
                table: "Facture",
                columns: new[] { "ClientFk", "ProductFk", "DateAchat" });

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ProductFk",
                table: "Facture",
                column: "ProductFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Facture",
                table: "Facture");

            migrationBuilder.DropIndex(
                name: "IX_Facture_ProductFk",
                table: "Facture");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facture",
                table: "Facture",
                columns: new[] { "ProductFk", "ClientFk", "DateAchat" });

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ClientFk",
                table: "Facture",
                column: "ClientFk");
        }
    }
}
