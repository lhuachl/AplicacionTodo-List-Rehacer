using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AplicacionTodo_List_Rehacer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCompletada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "FechaCreacion", "Nombre" },
                values: new object[] { 1, "demo@ejemplo.com", new DateTime(2025, 9, 1, 23, 53, 17, 930, DateTimeKind.Local).AddTicks(9904), "Usuario Demo" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "Descripcion", "Estado", "FechaCompletada", "FechaCreacion", "FechaVencimiento", "Prioridad", "Titulo", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Esta es una tarea de ejemplo en estado 'Por hacer'", 1, null, new DateTime(2025, 9, 1, 23, 53, 17, 931, DateTimeKind.Local).AddTicks(8037), null, 2, "Tarea de ejemplo - Por hacer", 1 },
                    { 2, "Esta es una tarea de ejemplo en estado 'En progreso'", 2, null, new DateTime(2025, 9, 1, 23, 53, 17, 931, DateTimeKind.Local).AddTicks(8403), null, 3, "Tarea de ejemplo - En progreso", 1 },
                    { 3, "Esta es una tarea de ejemplo completada", 3, new DateTime(2025, 8, 31, 23, 53, 17, 931, DateTimeKind.Local).AddTicks(8558), new DateTime(2025, 8, 30, 23, 53, 17, 931, DateTimeKind.Local).AddTicks(8478), null, 1, "Tarea de ejemplo - Completada", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_UsuarioId",
                table: "Tareas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
