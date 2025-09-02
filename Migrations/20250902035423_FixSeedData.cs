using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionTodo_List_Rehacer.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCompletada", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 12, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 1, 23, 53, 17, 931, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 1, 23, 53, 17, 931, DateTimeKind.Local).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCompletada", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 8, 31, 23, 53, 17, 931, DateTimeKind.Local).AddTicks(8558), new DateTime(2025, 8, 30, 23, 53, 17, 931, DateTimeKind.Local).AddTicks(8478) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 1, 23, 53, 17, 930, DateTimeKind.Local).AddTicks(9904));
        }
    }
}
