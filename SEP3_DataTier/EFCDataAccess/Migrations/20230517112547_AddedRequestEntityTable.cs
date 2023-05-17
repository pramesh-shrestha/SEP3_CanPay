using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedRequestEntityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_PayerUsername",
                schema: "CanPay",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_PayerUsername",
                schema: "CanPay",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "PayerUsername",
                schema: "CanPay",
                table: "Requests",
                newName: "RequestedDate");

            migrationBuilder.AddColumn<string>(
                name: "RequestReceiverUsername",
                schema: "CanPay",
                table: "Requests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestSenderUsername",
                schema: "CanPay",
                table: "Requests",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestReceiverUsername",
                schema: "CanPay",
                table: "Requests",
                column: "RequestReceiverUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestSenderUsername",
                schema: "CanPay",
                table: "Requests",
                column: "RequestSenderUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_RequestReceiverUsername",
                schema: "CanPay",
                table: "Requests",
                column: "RequestReceiverUsername",
                principalSchema: "CanPay",
                principalTable: "Users",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_RequestSenderUsername",
                schema: "CanPay",
                table: "Requests",
                column: "RequestSenderUsername",
                principalSchema: "CanPay",
                principalTable: "Users",
                principalColumn: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_RequestReceiverUsername",
                schema: "CanPay",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_RequestSenderUsername",
                schema: "CanPay",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestReceiverUsername",
                schema: "CanPay",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestSenderUsername",
                schema: "CanPay",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestReceiverUsername",
                schema: "CanPay",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestSenderUsername",
                schema: "CanPay",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestedDate",
                schema: "CanPay",
                table: "Requests",
                newName: "PayerUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PayerUsername",
                schema: "CanPay",
                table: "Requests",
                column: "PayerUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_PayerUsername",
                schema: "CanPay",
                table: "Requests",
                column: "PayerUsername",
                principalSchema: "CanPay",
                principalTable: "Users",
                principalColumn: "Username");
        }
    }
}
