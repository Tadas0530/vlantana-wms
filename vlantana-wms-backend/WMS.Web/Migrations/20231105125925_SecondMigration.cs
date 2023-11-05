using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vlantana_wms_backend.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderModels_ClientModels_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModels_ClientModels_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "ClientModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PalleteModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDefective = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateArrived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExported = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalleteModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PalleteModels_ClientModels_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PalleteModels_OrderModels_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PalleteId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModels_ClientModels_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductModels_OrderModels_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductModels_PalleteModels_PalleteId",
                        column: x => x.PalleteId,
                        principalTable: "PalleteModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderModels_ClientId",
                table: "OrderModels",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PalleteModels_ClientId",
                table: "PalleteModels",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PalleteModels_OrderId",
                table: "PalleteModels",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_ClientId",
                table: "ProductModels",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_OrderId",
                table: "ProductModels",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_PalleteId",
                table: "ProductModels",
                column: "PalleteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModels_ClientId1",
                table: "UserModels",
                column: "ClientId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropTable(
                name: "PalleteModels");

            migrationBuilder.DropTable(
                name: "OrderModels");

            migrationBuilder.DropTable(
                name: "ClientModels");
        }
    }
}
