using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class TablePorteuseDeDonnees2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Client_ClientCIN",
                table: "Facture");

            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Products_ProductId",
                table: "Facture");

            migrationBuilder.DropIndex(
                name: "IX_Facture_ClientCIN",
                table: "Facture");

            migrationBuilder.DropIndex(
                name: "IX_Facture_ProductId",
                table: "Facture");

            migrationBuilder.DropColumn(
                name: "ClientCIN",
                table: "Facture");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Facture");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ClientFk",
                table: "Facture",
                column: "ClientFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Client_ClientFk",
                table: "Facture",
                column: "ClientFk",
                principalTable: "Client",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Products_ProductFk",
                table: "Facture",
                column: "ProductFk",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Client_ClientFk",
                table: "Facture");

            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Products_ProductFk",
                table: "Facture");

            migrationBuilder.DropIndex(
                name: "IX_Facture_ClientFk",
                table: "Facture");

            migrationBuilder.AddColumn<int>(
                name: "ClientCIN",
                table: "Facture",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Facture",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ClientCIN",
                table: "Facture",
                column: "ClientCIN");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ProductId",
                table: "Facture",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Client_ClientCIN",
                table: "Facture",
                column: "ClientCIN",
                principalTable: "Client",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Products_ProductId",
                table: "Facture",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
