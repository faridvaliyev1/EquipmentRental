using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentRental.Migrations
{
    public partial class order2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EquipmentId",
                table: "Orders",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Equipments_EquipmentId",
                table: "Orders",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Equipments_EquipmentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EquipmentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Orders");
        }
    }
}
