using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinanceManagement.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mcc",
                table: "Transactions",
                newName: "Mcc");

            migrationBuilder.RenameColumn(
                name: "kind",
                table: "Transactions",
                newName: "Kind");

            migrationBuilder.RenameColumn(
                name: "direction",
                table: "Transactions",
                newName: "Direction");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "Transactions",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "beneficiaryname",
                table: "Transactions",
                newName: "Beneficiaryname");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.AlterColumn<int>(
                name: "Direction",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Transactions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mcc",
                table: "Transactions",
                newName: "mcc");

            migrationBuilder.RenameColumn(
                name: "Kind",
                table: "Transactions",
                newName: "kind");

            migrationBuilder.RenameColumn(
                name: "Direction",
                table: "Transactions",
                newName: "direction");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Transactions",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "Beneficiaryname",
                table: "Transactions",
                newName: "beneficiaryname");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "amount");

            migrationBuilder.AlterColumn<string>(
                name: "direction",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "currency",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
