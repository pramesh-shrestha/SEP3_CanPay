using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillTransactions_Users_PayeeUsername",
                schema: "CanPay",
                table: "BillTransactions");

            migrationBuilder.DropIndex(
                name: "IX_BillTransactions_PayeeUsername",
                schema: "CanPay",
                table: "BillTransactions");

            migrationBuilder.RenameColumn(
                name: "PayeeUsername",
                schema: "CanPay",
                table: "BillTransactions",
                newName: "Payee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Payee",
                schema: "CanPay",
                table: "BillTransactions",
                newName: "PayeeUsername");

            migrationBuilder.CreateIndex(
                name: "IX_BillTransactions_PayeeUsername",
                schema: "CanPay",
                table: "BillTransactions",
                column: "PayeeUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_BillTransactions_Users_PayeeUsername",
                schema: "CanPay",
                table: "BillTransactions",
                column: "PayeeUsername",
                principalSchema: "CanPay",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
