using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vlantana_wms_backend.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallete_Client_ClientId",
                table: "Pallete");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Client_ClientId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Client_ClientId1",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ClientId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "ClientId1",
                table: "User",
                newName: "UserCredentialsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Product",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ClientId",
                table: "Product",
                newName: "IX_Product_CompanyId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Pallete",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pallete",
                newName: "PalleteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pallete_ClientId",
                table: "Pallete",
                newName: "IX_Pallete_CompanyId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Order",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                newName: "IX_Order_CompanyId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Credentials",
                newName: "UserCredentialsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Client",
                newName: "CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "User",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Pallete",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Credentials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Credentials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Credentials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Credentials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Client",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_UserId",
                table: "Credentials",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_User_UserId",
                table: "Credentials",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_CompanyId",
                table: "Order",
                column: "CompanyId",
                principalTable: "Client",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallete_Client_CompanyId",
                table: "Pallete",
                column: "CompanyId",
                principalTable: "Client",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Client_CompanyId",
                table: "Product",
                column: "CompanyId",
                principalTable: "Client",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Client_CompanyId",
                table: "User",
                column: "CompanyId",
                principalTable: "Client",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_User_UserId",
                table: "Credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_CompanyId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallete_Client_CompanyId",
                table: "Pallete");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Client_CompanyId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Client_CompanyId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CompanyId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Credentials_UserId",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pallete");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "UserCredentialsId",
                table: "User",
                newName: "ClientId1");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Product",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CompanyId",
                table: "Product",
                newName: "IX_Product_ClientId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Pallete",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "PalleteId",
                table: "Pallete",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pallete_CompanyId",
                table: "Pallete",
                newName: "IX_Pallete_ClientId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Order",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CompanyId",
                table: "Order",
                newName: "IX_Order_ClientId");

            migrationBuilder.RenameColumn(
                name: "UserCredentialsId",
                table: "Credentials",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Client",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Credentials",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Credentials",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Credentials",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_ClientId1",
                table: "User",
                column: "ClientId1");

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
                name: "FK_Product_Client_ClientId",
                table: "Product",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Client_ClientId1",
                table: "User",
                column: "ClientId1",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
