using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class watchupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonnelName",
                table: "Watches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 24, 20, 35, 18, 542, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 24, 20, 35, 18, 542, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 24, 20, 35, 18, 542, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 24, 20, 35, 18, 542, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 24, 20, 35, 18, 542, DateTimeKind.Local).AddTicks(9823));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 24, 20, 35, 18, 542, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonnelName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonnelName",
                table: "Watches");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4999));
        }
    }
}
