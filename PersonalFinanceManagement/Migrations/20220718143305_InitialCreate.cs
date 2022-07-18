using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinanceManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "TEXT", nullable: false),
                    beneficiaryname = table.Column<string>(type: "TEXT", nullable: true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    direction = table.Column<string>(type: "TEXT", nullable: false),
                    amount = table.Column<float>(type: "REAL", nullable: false),
                    currency = table.Column<int>(type: "INTEGER", nullable: false),
                    mcc = table.Column<string>(type: "TEXT", nullable: true),
                    kind = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
