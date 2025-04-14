using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModelsDb_CarStylesDb_CarStyleStyleId",
                table: "CarModelsDb");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsDb_CarModelsDb_CarModelModelId",
                table: "CarsDb");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDb_PaymentsDb_PaymentId",
                table: "OrdersDb");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDb_PromotionsDb_PromotionId",
                table: "OrdersDb");

            migrationBuilder.DropIndex(
                name: "IX_CarsDb_CarModelModelId",
                table: "CarsDb");

            migrationBuilder.DropIndex(
                name: "IX_CarModelsDb_CarStyleStyleId",
                table: "CarModelsDb");

            migrationBuilder.DropColumn(
                name: "CarModelModelId",
                table: "CarsDb");

            migrationBuilder.DropColumn(
                name: "CarStyleStyleId",
                table: "CarModelsDb");

            migrationBuilder.CreateIndex(
                name: "IX_CarsDb_ModelId",
                table: "CarsDb",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelsDb_StyleId",
                table: "CarModelsDb",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelsDb_CarStylesDb_StyleId",
                table: "CarModelsDb",
                column: "StyleId",
                principalTable: "CarStylesDb",
                principalColumn: "StyleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsDb_CarModelsDb_ModelId",
                table: "CarsDb",
                column: "ModelId",
                principalTable: "CarModelsDb",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDb_PaymentsDb_PaymentId",
                table: "OrdersDb",
                column: "PaymentId",
                principalTable: "PaymentsDb",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDb_PromotionsDb_PromotionId",
                table: "OrdersDb",
                column: "PromotionId",
                principalTable: "PromotionsDb",
                principalColumn: "PromotionId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModelsDb_CarStylesDb_StyleId",
                table: "CarModelsDb");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsDb_CarModelsDb_ModelId",
                table: "CarsDb");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDb_PaymentsDb_PaymentId",
                table: "OrdersDb");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDb_PromotionsDb_PromotionId",
                table: "OrdersDb");

            migrationBuilder.DropIndex(
                name: "IX_CarsDb_ModelId",
                table: "CarsDb");

            migrationBuilder.DropIndex(
                name: "IX_CarModelsDb_StyleId",
                table: "CarModelsDb");

            migrationBuilder.AddColumn<int>(
                name: "CarModelModelId",
                table: "CarsDb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarStyleStyleId",
                table: "CarModelsDb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarsDb_CarModelModelId",
                table: "CarsDb",
                column: "CarModelModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelsDb_CarStyleStyleId",
                table: "CarModelsDb",
                column: "CarStyleStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelsDb_CarStylesDb_CarStyleStyleId",
                table: "CarModelsDb",
                column: "CarStyleStyleId",
                principalTable: "CarStylesDb",
                principalColumn: "StyleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsDb_CarModelsDb_CarModelModelId",
                table: "CarsDb",
                column: "CarModelModelId",
                principalTable: "CarModelsDb",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDb_PaymentsDb_PaymentId",
                table: "OrdersDb",
                column: "PaymentId",
                principalTable: "PaymentsDb",
                principalColumn: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDb_PromotionsDb_PromotionId",
                table: "OrdersDb",
                column: "PromotionId",
                principalTable: "PromotionsDb",
                principalColumn: "PromotionId");
        }
    }
}
