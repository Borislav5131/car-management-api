using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_management_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Garages_GarageId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Cars_GarageId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GarageId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "GarageId",
                table: "Maintenances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Maintenances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CarName",
                table: "Maintenances",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GarageName",
                table: "Maintenances",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Garages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_CarId",
                table: "Maintenances",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_CarId",
                table: "Garages",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Cars_CarId",
                table: "Garages",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Cars_CarId",
                table: "Maintenances",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Garages_GarageId",
                table: "Maintenances",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Cars_CarId",
                table: "Garages");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Cars_CarId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Garages_GarageId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_CarId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Garages_CarId",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "CarName",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "GarageName",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Garages");

            migrationBuilder.AlterColumn<int>(
                name: "GarageId",
                table: "Maintenances",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "GarageId",
                table: "Cars",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GarageId",
                table: "Cars",
                column: "GarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Garages_GarageId",
                table: "Cars",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Garages_GarageId",
                table: "Maintenances",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id");
        }
    }
}
