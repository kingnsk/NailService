using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NailService.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfWork",
                columns: table => new
                {
                    WorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TypeOfService = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfWork", x => x.WorkId);
                    table.ForeignKey(
                        name: "FK_TypeOfWork_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appountments",
                columns: table => new
                {
                    AppountmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfReceipt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfReceipt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appountments", x => x.AppountmentId);
                    table.ForeignKey(
                        name: "FK_Appountments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appountments_TypeOfWork_WorkId",
                        column: x => x.WorkId,
                        principalTable: "TypeOfWork",
                        principalColumn: "WorkId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appountments_ClientId",
                table: "Appountments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appountments_WorkId",
                table: "Appountments",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfWork_ClientId",
                table: "TypeOfWork",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appountments");

            migrationBuilder.DropTable(
                name: "TypeOfWork");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
