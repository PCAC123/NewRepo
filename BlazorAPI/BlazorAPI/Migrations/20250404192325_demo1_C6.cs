using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class demo1_C6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarStylesDb",
                columns: table => new
                {
                    StyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarStylesDb", x => x.StyleId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsDb",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsDb", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "PromotionsDb",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionsDb", x => x.PromotionId);
                });

            migrationBuilder.CreateTable(
                name: "UsersDb",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDb", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CarModelsDb",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    CarStyleStyleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelsDb", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_CarModelsDb_CarStylesDb_CarStyleStyleId",
                        column: x => x.CarStyleStyleId,
                        principalTable: "CarStylesDb",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDb",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    PromotionId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDb", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrdersDb_PaymentsDb_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PaymentsDb",
                        principalColumn: "PaymentId");
                    table.ForeignKey(
                        name: "FK_OrdersDb_PromotionsDb_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "PromotionsDb",
                        principalColumn: "PromotionId");
                    table.ForeignKey(
                        name: "FK_OrdersDb_UsersDb_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersDb",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarsDb",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    CarModelModelId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsDb", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_CarsDb_CarModelsDb_CarModelModelId",
                        column: x => x.CarModelModelId,
                        principalTable: "CarModelsDb",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailsDb",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailsDb", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetailsDb_CarsDb_CarId",
                        column: x => x.CarId,
                        principalTable: "CarsDb",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailsDb_OrdersDb_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrdersDb",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewHistoriesDb",
                columns: table => new
                {
                    ViewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ViewedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewHistoriesDb", x => x.ViewId);
                    table.ForeignKey(
                        name: "FK_ViewHistoriesDb_CarsDb_CarId",
                        column: x => x.CarId,
                        principalTable: "CarsDb",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViewHistoriesDb_UsersDb_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersDb",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModelsDb_CarStyleStyleId",
                table: "CarModelsDb",
                column: "CarStyleStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelsDb_ModelName",
                table: "CarModelsDb",
                column: "ModelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarsDb_CarModelModelId",
                table: "CarsDb",
                column: "CarModelModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarStylesDb_StyleName",
                table: "CarStylesDb",
                column: "StyleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsDb_CarId",
                table: "OrderDetailsDb",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsDb_OrderId",
                table: "OrderDetailsDb",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDb_PaymentId",
                table: "OrdersDb",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDb_PromotionId",
                table: "OrdersDb",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDb_UserId",
                table: "OrdersDb",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDb_Email",
                table: "UsersDb",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViewHistoriesDb_CarId",
                table: "ViewHistoriesDb",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewHistoriesDb_UserId",
                table: "ViewHistoriesDb",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailsDb");

            migrationBuilder.DropTable(
                name: "ViewHistoriesDb");

            migrationBuilder.DropTable(
                name: "OrdersDb");

            migrationBuilder.DropTable(
                name: "CarsDb");

            migrationBuilder.DropTable(
                name: "PaymentsDb");

            migrationBuilder.DropTable(
                name: "PromotionsDb");

            migrationBuilder.DropTable(
                name: "UsersDb");

            migrationBuilder.DropTable(
                name: "CarModelsDb");

            migrationBuilder.DropTable(
                name: "CarStylesDb");
        }
    }
}
