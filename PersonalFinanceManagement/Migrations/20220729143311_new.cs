using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinanceManagement.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    ParentCode = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ParentCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "subcategories",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    ParentCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategories", x => x.Code);
                    table.ForeignKey(
                        name: "FK_subcategories_Category_Code",
                        column: x => x.Code,
                        principalTable: "Category",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Beneficiaryname = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Direction = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    Mcc = table.Column<int>(type: "INTEGER", nullable: true),
                    Kind = table.Column<string>(type: "TEXT", nullable: false),
                    Catcode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_Category_Catcode",
                        column: x => x.Catcode,
                        principalTable: "Category",
                        principalColumn: "Code");
                });

            /*  migrationBuilder.CreateTable(
                  name: "Transactions",
                  columns: table => new
                  {
                      Id = table.Column<string>(type: "TEXT", nullable: false),
                      BeneficiaryName = table.Column<string>(type: "TEXT", nullable: true),
                      Date = table.Column<string>(type: "TEXT", nullable: false),
                      Direction = table.Column<int>(type: "INTEGER", nullable: false),
                      Amount = table.Column<double>(type: "REAL", nullable: false),
                      Description = table.Column<string>(type: "TEXT", nullable: false),
                      Currency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                      Mcc = table.Column<int>(type: "INTEGER", nullable: true),
                      Kind = table.Column<int>(type: "INTEGER", nullable: false),
                      Catcode = table.Column<string>(type: "TEXT", nullable: true)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_Transactions", x => x.Id);
                      table.ForeignKey(
                          name: "FK_Transactions_Category_Catcode",
                          column: x => x.Catcode,
                          principalTable: "Category",
                          principalColumn: "Code");
                  });

           

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Catcode",
                table: "Transactions",
                column: "Catcode");
            */
            migrationBuilder.CreateIndex(
               name: "IX_transactions_Catcode",
               table: "transactions",
               column: "Catcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "subcategories");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
