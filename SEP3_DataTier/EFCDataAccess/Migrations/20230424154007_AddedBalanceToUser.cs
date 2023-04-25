using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedBalanceToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Balance",
                schema: "CanPay",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                schema: "CanPay",
                table: "Users");
        }
    }
}
