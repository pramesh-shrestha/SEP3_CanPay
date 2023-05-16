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
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                schema: "CanPay",
                table: "Requests",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                schema: "CanPay",
                table: "Requests");
        }
    }
}
