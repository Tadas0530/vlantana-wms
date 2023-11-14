using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vlantana_wms_backend.Migrations
{
    /// <inheritdoc />
    public partial class Refresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModels_ClientModels_ClientId",
                table: "OrderModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PalleteModels_ClientModels_ClientId",
                table: "PalleteModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PalleteModels_OrderModels_OrderId",
                table: "PalleteModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_ClientModels_ClientId",
                table: "ProductModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_OrderModels_OrderId",
                table: "ProductModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_PalleteModels_PalleteId",
                table: "ProductModels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModels_ClientModels_ClientId1",
                table: "UserModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserModels",
                table: "UserModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModels",
                table: "ProductModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PalleteModels",
                table: "PalleteModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientModels",
                table: "ClientModels");

            migrationBuilder.RenameTable(
                name: "UserModels",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "ProductModels",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "PalleteModels",
                newName: "Pallete");

            migrationBuilder.RenameTable(
                name: "OrderModels",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "ClientModels",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_UserModels_ClientId1",
                table: "User",
                newName: "IX_User_ClientId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModels_PalleteId",
                table: "Product",
                newName: "IX_Product_PalleteId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModels_OrderId",
                table: "Product",
                newName: "IX_Product_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModels_ClientId",
                table: "Product",
                newName: "IX_Product_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_PalleteModels_OrderId",
                table: "Pallete",
                newName: "IX_Pallete_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PalleteModels_ClientId",
                table: "Pallete",
                newName: "IX_Pallete_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModels_ClientId",
                table: "Order",
                newName: "IX_Order_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pallete",
                table: "Pallete",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_ClientId",
                table: "Order",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallete_Client_ClientId",
                table: "Pallete",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallete_Order_OrderId",
                table: "Pallete",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Client_ClientId",
                table: "Product",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Pallete_PalleteId",
                table: "Product",
                column: "PalleteId",
                principalTable: "Pallete",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Client_ClientId1",
                table: "User",
                column: "ClientId1",
                principalTable: "Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallete_Client_ClientId",
                table: "Pallete");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallete_Order_OrderId",
                table: "Pallete");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Client_ClientId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Pallete_PalleteId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Client_ClientId1",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pallete",
                table: "Pallete");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UserModels");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "ProductModels");

            migrationBuilder.RenameTable(
                name: "Pallete",
                newName: "PalleteModels");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "OrderModels");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "ClientModels");

            migrationBuilder.RenameIndex(
                name: "IX_User_ClientId1",
                table: "UserModels",
                newName: "IX_UserModels_ClientId1");

            migrationBuilder.RenameIndex(
                name: "IX_Product_PalleteId",
                table: "ProductModels",
                newName: "IX_ProductModels_PalleteId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_OrderId",
                table: "ProductModels",
                newName: "IX_ProductModels_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ClientId",
                table: "ProductModels",
                newName: "IX_ProductModels_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Pallete_OrderId",
                table: "PalleteModels",
                newName: "IX_PalleteModels_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Pallete_ClientId",
                table: "PalleteModels",
                newName: "IX_PalleteModels_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientId",
                table: "OrderModels",
                newName: "IX_OrderModels_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserModels",
                table: "UserModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModels",
                table: "ProductModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PalleteModels",
                table: "PalleteModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientModels",
                table: "ClientModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModels_ClientModels_ClientId",
                table: "OrderModels",
                column: "ClientId",
                principalTable: "ClientModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PalleteModels_ClientModels_ClientId",
                table: "PalleteModels",
                column: "ClientId",
                principalTable: "ClientModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PalleteModels_OrderModels_OrderId",
                table: "PalleteModels",
                column: "OrderId",
                principalTable: "OrderModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_ClientModels_ClientId",
                table: "ProductModels",
                column: "ClientId",
                principalTable: "ClientModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_OrderModels_OrderId",
                table: "ProductModels",
                column: "OrderId",
                principalTable: "OrderModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_PalleteModels_PalleteId",
                table: "ProductModels",
                column: "PalleteId",
                principalTable: "PalleteModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserModels_ClientModels_ClientId1",
                table: "UserModels",
                column: "ClientId1",
                principalTable: "ClientModels",
                principalColumn: "Id");
        }
    }
}
