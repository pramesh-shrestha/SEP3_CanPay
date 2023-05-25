using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBillTransactionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillTransactions",
                schema: "CanPay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PayerUsername = table.Column<string>(type: "text", nullable: false),
                    PayeeUsername = table.Column<string>(type: "text", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillTransactions_Users_PayeeUsername",
                        column: x => x.PayeeUsername,
                        principalSchema: "CanPay",
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillTransactions_Users_PayerUsername",
                        column: x => x.PayerUsername,
                        principalSchema: "CanPay",
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillTransactions_PayeeUsername",
                schema: "CanPay",
                table: "BillTransactions",
                column: "PayeeUsername");

            migrationBuilder.CreateIndex(
                name: "IX_BillTransactions_PayerUsername",
                schema: "CanPay",
                table: "BillTransactions",
                column: "PayerUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillTransactions",
                schema: "CanPay");
        }
    }
}
