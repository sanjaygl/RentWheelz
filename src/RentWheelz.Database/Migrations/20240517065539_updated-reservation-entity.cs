using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentWheelz.Database.Migrations
{
    /// <inheritdoc />
    public partial class updatedreservationentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserEmail",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserEmail",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Reservations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Reservations",
                type: "character varying(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarID",
                table: "Reservations",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserEmail",
                table: "Reservations",
                column: "UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserEmail",
                table: "Reservations",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
