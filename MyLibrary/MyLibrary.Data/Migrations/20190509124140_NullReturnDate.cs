using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Data.Migrations
{
    public partial class NullReturnDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookBorrowerses",
                table: "BookBorrowerses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "BookBorrowerses",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookBorrowerses",
                table: "BookBorrowerses",
                columns: new[] { "BookId", "BorrowerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookBorrowerses",
                table: "BookBorrowerses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "BookBorrowerses",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookBorrowerses",
                table: "BookBorrowerses",
                columns: new[] { "BookId", "BorrowerId", "BorrowDate" });
        }
    }
}
